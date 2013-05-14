using System;
using System.Reactive.Concurrency;

namespace RxDebugger
{
    public class Debugger
    {
        public Debugger(IScheduler scheduler, Action<DebugNotification> recorder)
        {
            this.Scheduler = scheduler;
            this.Recorder = recorder;
        }

        public IScheduler Scheduler { get; private set; }
        public Action<DebugNotification> Recorder { get; private set; }
    }
}
