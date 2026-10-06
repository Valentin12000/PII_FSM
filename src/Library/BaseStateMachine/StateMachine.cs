

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Ucu.Poo.Fsm
{
    public class StateMachine
    {
        private State baseState;
        public State currentState{set; get;}
        //private List<State> states;
        private Dictionary<Type, State> states;
        public ReadOnlyCollection<State> States{get {return this.states.Values.ToList().AsReadOnly<State>();}}


        public StateMachine(List<State> states, State baseState = null)
        {
            this.baseState = baseState;
            foreach(State state in states)
            {
                this.AddState(state);
            }

            if(baseState == null)
            {
                this.baseState = states[0];
            }

            this.currentState = baseState;
        }

        public void AddState(State state)
        {
            Type newStateType = state.GetType();
            if(!this.states.ContainsKey(newStateType))
            {
                this.states.Add(newStateType, state);
            }
        }

        public bool ProcessInput(Input input)
        {
            State newState = currentState.GetNextState(input);
            if(newState == null) return false;

            currentState.OnExit();
            currentState = states.GetValueOrDefault(newState.GetType());
            currentState.OnEnter();
            return true;
        }

        public bool ProcessInputs(Input[] inputs)
        {
            bool didChange = false;

            foreach(Input input in inputs)
            {
                if(ProcessInput(input)) didChange = true;
            }

            return didChange;
        }
    }
}