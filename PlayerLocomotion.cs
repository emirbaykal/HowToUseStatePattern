using UnityEngine;

namespace HowToUseStatePattern.MainFolder
{
    public interface ILocomotionContext
    {
        void SetState(ILocomotionState newState);
    }

    public interface ILocomotionState
    {
        void Jump(ILocomotionContext context);
        void Fall(ILocomotionContext context);
        void Land(ILocomotionContext context);
        void Crouch(ILocomotionContext context);
    }
    public class PlayerLocomotion : MonoBehaviour, ILocomotionContext
    {
        ILocomotionState _currentState = new GroundedState();

        public void Crouch() => _currentState.Crouch(this);
        public void Fall() => _currentState.Fall(this);
        public void Jump() => _currentState.Jump(this);
        public void Land() => _currentState.Land(this);

        void ILocomotionContext.SetState(ILocomotionState newState)
        {
            _currentState = newState;
        }
    }

    public class GroundedState : ILocomotionState
    {
        public void Jump(ILocomotionContext context)
        {
            context.SetState(new InAirState());
        }

        public void Fall(ILocomotionContext context)
        {
            context.SetState(new InAirState());
        }

        public void Land(ILocomotionContext context)
        {
        }

        public void Crouch(ILocomotionContext context)
        {
            context.SetState(new CrouchingState());
        }
    }

    public class CrouchingState : ILocomotionState
    {
        public void Jump(ILocomotionContext context)
        {
            context.SetState(new GroundedState());
        }

        public void Fall(ILocomotionContext context)
        {
            context.SetState(new InAirState());
        }

        public void Land(ILocomotionContext context)
        {
        }

        public void Crouch(ILocomotionContext context)
        {
            context.SetState(new GroundedState());
        }
    }

    public class InAirState : ILocomotionState
    {
        public void Jump(ILocomotionContext context)
        {
        }

        public void Fall(ILocomotionContext context)
        {
        }

        public void Land(ILocomotionContext context)
        {
            context.SetState(new GroundedState());
        }

        public void Crouch(ILocomotionContext context)
        {
        }
    }
    
}