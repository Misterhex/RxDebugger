using System;

namespace RxDebugger
{
    public static partial class DebuggedObservable
    {
        public static IDebuggedObservable<T> EnableDebugging<T>(this IObservable<T> source, string sourceName, Debugger debugger)
        {
            var sourceNameWithId = string.Format("[{0}]{1}", Guid.NewGuid(), sourceName);
            return new DebuggedObservable<T>(source, sourceNameWithId, debugger);
        }
    }
}
