using System;
using System.Reactive;

namespace RxDebugger
{
    public sealed class DebugNotification
    {
        public DebugNotification(string sourceName, Timestamped<Notification<object>> value)
        {
            this.SourceName = sourceName;
            this.Timestamp = value.Timestamp;
            this.Notification = value.Value;
        }

        public string SourceName { get; private set; }
        public DateTimeOffset Timestamp { get; private set; }
        public Notification<object> Notification { get; private set; }
    }
}
