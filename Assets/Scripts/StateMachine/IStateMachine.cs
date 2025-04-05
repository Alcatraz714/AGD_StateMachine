using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatePattern.Enemy;

namespace StatePattern.StateMachine
{
    public interface IStateMachine
    {
       public void ChangeState(States newState);
    }

    public enum States
    {
        IDLE,
        ROTATING,
        SHOOTING,
        PATROLLING,
        CHASING
    }
}
