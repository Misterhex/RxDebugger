using System;
using System.Reactive;
using System.Reactive.Linq;

namespace RxDebugger
{
    public partial class DebuggedObservable<T> : ObservableBase<T>, IDebuggedObservable<T>
    {
        IObservable<T> _source;

        public DebuggedObservable(IObservable<T> source, string sourceName, Debugger debugger)
        {
            _source = source;
            this.SourceName = sourceName;
            this.Debugger = debugger;
        }

        protected override IDisposable SubscribeCore(IObserver<T> observer)
        {
            return _source
                    .Select(_ => (object)_)
                    .Materialize()
                    .Timestamp(Debugger.Scheduler)
                    .Do(Record)
                    .Select(t => t.Value)
                    .Dematerialize()
                    .Select(_ => (T)_)
                    .Subscribe(observer);
        }

        public Debugger Debugger { get; private set; }

        private void Record(Timestamped<Notification<object>> value)
        {
            this.Debugger.Recorder(new DebugNotification(this.SourceName, value));
        }

        public string SourceName { get; private set; }
    }
}