using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxDebugger
{
    public class GroupedDebuggedObservable<TKey, TElement> : DebuggedObservable<TElement>, IGroupedDebuggedObservable<TKey, TElement>
    {
        public GroupedDebuggedObservable(IGroupedObservable<TKey, TElement> source, string sourceName, Debugger debugger)
            : base(source, sourceName,debugger)
        {
            this.Key = source.Key;
        }

        public TKey Key { get; private set; }
    }
}
