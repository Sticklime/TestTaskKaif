using System;

namespace CodeBase
{
    public interface IChangedObserver
    {
        void AddListenerIsChanged(Action action);
        void RemoveListenerIsChanged(Action action);
    }
}