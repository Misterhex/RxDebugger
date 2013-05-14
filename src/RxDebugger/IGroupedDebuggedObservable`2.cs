using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxDebugger
{
    public interface IGroupedDebuggedObservable<out TKey, out TElement> : IDebuggedObservable<TElement>, IGroupedObservable<TKey, TElement>
    {
    }
}
