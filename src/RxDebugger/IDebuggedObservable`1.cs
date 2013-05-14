using System;

namespace RxDebugger
{
    public interface IDebuggedObservable<out T> : IObservable<T>
    {
        string SourceName { get; }
        Debugger Debugger { get; } 
    }
}
