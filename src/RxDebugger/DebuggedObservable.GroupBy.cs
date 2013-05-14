using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxDebugger
{
    public static partial class DebuggedObservable
    {
        public static IDebuggedObservable<IGroupedDebuggedObservable<TKey, TSource>> GroupBy<TSource, TKey>(this IDebuggedObservable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var sourceName = source.SourceName + ".GroupBy";
            var grouped = Observable
                            .GroupBy(source, keySelector)
                            .Select((g, i) => 
                                new GroupedDebuggedObservable<TKey, TSource>(g, sourceName + "[" + i.ToString() + "]", source.Debugger));
            
            return new DebuggedObservable<IGroupedDebuggedObservable<TKey, TSource>>(
                grouped, sourceName, source.Debugger);
        }
    }
}
