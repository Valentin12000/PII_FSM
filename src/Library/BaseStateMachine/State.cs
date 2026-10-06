

using System.Collections.Generic;
using Discord.Interactions;

namespace Ucu.Poo.Fsm
{
    public class State
    {
        private List<Transition> transitions;

        public State(List<Transition> transitions)
        {
            this.transitions = new List<Transition>();
            this.transitions.AddRange(transitions);
        }

        public void AddTransition(Input input, State state)
        {
            transitions.Add(new Transition(input, state));
        }

        public State GetNextState(Input input)
        {
            State nextState = null;
            foreach(Transition transition in transitions)
            {
                if(transition.IsTriggeredBy(input))
                {
                    nextState = transition.NextState;
                    break;
                }
            }
            return nextState;
        }

        public virtual void OnEnter(){}

        public virtual void OnExit(){}
    }
}