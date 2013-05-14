using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Microsoft.Reactive.Testing;
using Xunit;

namespace RxDebugger.Tests
{
    public class DebuggedObservableWhereTests
    {
        private TestScheduler _scheduler;
        public DebuggedObservableWhereTests()
        {
            _scheduler = new TestScheduler();
        }

        [Fact]
        public void Should_record_where_operator()
        {
            var list = new List<DebugNotification>();
            var debugger = new Debugger(_scheduler, list.Add);
            var timer = Observable.Interval(TimeSpan.FromSeconds(1), _scheduler)
                          .Take(5)
                          .EnableDebugging("timer", debugger)
                          .Where(i => i % 2 == 0);

            using (timer.Subscribe())
            {
                _scheduler.AdvanceBy(TimeSpan.FromSeconds(5).Ticks);
                Assert.Equal(10, list.Count);
                Assert.Equal(6, list.Where(n => n.SourceName.EndsWith("timer")).Count());
                Assert.Equal(1, list.Where(n => n.SourceName.EndsWith("timer") && n.Notification.Kind == NotificationKind.OnCompleted).Count());
                Assert.Equal(4, list.Where(n => n.SourceName.EndsWith("timer.Where")).Count());
                Assert.Equal(1, list.Where(n => n.SourceName.EndsWith("timer.Where") && n.Notification.Kind == NotificationKind.OnCompleted).Count());
            }
        }
    }
}
