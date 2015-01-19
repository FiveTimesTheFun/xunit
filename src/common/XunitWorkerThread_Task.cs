using System;
using System.Threading;
using System.Threading.Tasks;

namespace Xunit.Sdk
{
    internal class XunitWorkerThread
    {
        readonly Task task;

        public XunitWorkerThread(Action threadProc)
        {
            task = Task.Factory.StartNew(threadProc, 
                CancellationToken.None,
                TaskCreationOptions.LongRunning | TaskCreationOptions.DenyChildAttach, 
                TaskScheduler.Default);
        }

        public void Join()
        {
            task.GetAwaiter().GetResult();
        }

        public static void QueueUserWorkItem(Action backgroundTask)
        {
            Task.Run(backgroundTask);
        }
    }
}