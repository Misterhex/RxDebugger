using System;
using System.Reactive.Linq;

namespace RxDebugger
{
    public static partial class DebuggedObservable
    {
        public static IDebuggedObservable<TSource> Where<TSource>(this IDebuggedObservable<TSource> source, Func<TSource, bool> predicate)
        {
            var sourceName = source.SourceName + ".Where";
            return new DebuggedObservable<TSource>(Observable.Where(source, predicate), sourceName, source.Debugger);
        }

        public static IDebuggedObservable<TSource> Where<TSource>(this IDebuggedObservable<TSource> source, Func<TSource, int, bool> predicate)
        {
            var sourceName = source.SourceName + ".Where";
            return new DebuggedObservable<TSource>(Observable.Where(source, predicate), sourceName, source.Debugger);
        }

    }
}