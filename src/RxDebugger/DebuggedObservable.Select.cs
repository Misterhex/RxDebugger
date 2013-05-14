using System;
using System.Reactive.Linq;

namespace RxDebugger
{
    public static partial class DebuggedObservable
    {
        public static IDebuggedObservable<TResult> Select<T, TResult>(this IDebuggedObservable<T> source, Func<T, TResult> selector)
        {
            var sourceName = source.SourceName + ".Select";
            return new DebuggedObservable<TResult>(Observable.Select(source, selector), sourceName, source.Debugger);
        }

        public static IDebuggedObservable<TResult> Select<T, TResult>(this IDebuggedObservable<T> source, Func<T, int, TResult> selector)
        {
            var sourceName = source.SourceName + ".Select";
            return new DebuggedObservable<TResult>(Observable.Select(source, selector), sourceName, source.Debugger);
        }
    }
}
