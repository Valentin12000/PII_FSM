

using System.Collections.Generic;
using System.Linq;

namespace Ucu.Poo.Fsm
{
    public class StateMachine
    {
        private State baseState;
        public State currentState{set; get;}
        private List<State> states;


        public StateMachine(State baseState = null, List<State> states)
        {
            this.baseState = baseState;
            this.states = new List<State>();
            this.states.AddRange(states);

            if(baseState == null)
            {
                this.baseState = states[0];
            }

            this.currentState = baseState;
        }

        public void AddState(State state)
        {
            states.Add(state);
        }

        public bool ProcessInput(Input input)
        {
            //zzz
        }

        // public bool ProcessInputs(Input[] input)
        // {
            
        // }
    }
}