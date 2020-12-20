using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ABLibrary
{
    public abstract class State
    {
        public void SetStateMachine(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public virtual void OnEnter() { }
        public virtual void OnLeave() { }

        protected StateMachine _stateMachine = null;
    }

    public abstract class StateMachine
    {
        public virtual void SetState(State state)
        {
            if (_state != null)
                _state.OnLeave();

            _state = state;
            _state.SetStateMachine(this);

            if (_state != null)
                _state.OnEnter();
        }

        protected StateType GetState<StateType>() where StateType: State
        {
            return (StateType)_state;
        }

        private State _state = null;
    }
}


