

namespace Ucu.Poo.Fsm
{
    public class Transition
    {
        private Input triggerInput;
        public State NextState{get;}

        public Transition(Input trigger, State nextState)
        {
            this.triggerInput = trigger;
            this.NextState = nextState;
        }

        public bool IsTriggeredBy(Input input)
        {
            return input == triggerInput;
        }
    }
}