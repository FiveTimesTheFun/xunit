using System;
using System.Threading.Tasks;

namespace Xunit.Sdk
{
    internal class XunitWorkerThread
    {
        readonly Task task;

        public XunitWorkerThread(Action threadProc)
        {
            task = new Task(() => threadProc());
            task.Start();
        }

        public void Join()
        {
            task.Wait();
        }

        public static void QueueUserWorkItem(Action backgroundTask)
        {
            Task.Run(() => backgroundTask());
        }
    }
}