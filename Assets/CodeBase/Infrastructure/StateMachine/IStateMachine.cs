namespace CodeBase.Infrastructure.State
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : class, IState;
        void RegisterState<TState>(IExitableState state) where TState : IExitableState;
    }
}