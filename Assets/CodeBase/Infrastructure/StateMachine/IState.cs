﻿namespace CodeBase
{
    public interface IState : IExitableState
    {
        void Enter();
    }
    
    public interface IExitableState
    {
        void Exit();
    }
}