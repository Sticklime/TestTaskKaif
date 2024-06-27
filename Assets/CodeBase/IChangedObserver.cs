using System;

namespace CodeBase
{
    public interface IChangedObserver
    {
        event Action IsChanged;
        void AddListenerIsChanged(Action action);
        void RemoveListenerIsChanged(Action action);
    }
}