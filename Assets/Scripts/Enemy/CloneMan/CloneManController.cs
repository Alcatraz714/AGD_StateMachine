using StatePattern.Player;
using StatePattern.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class CloneManController : EnemyController
    {
        private CloneManStateMachine stateMachine;
        public int CloneCountLeft { get; private set; }

        public CloneManController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
        {
            SetCloneCount(2);
            enemyView.SetController(this);
            ChangeColor(UnityEngine.Color.red);
            CreateStateMachine();
            stateMachine.ChangeState(States.IDLE);
        }

        public void SetCloneCount(int cloneCountToSet) => CloneCountLeft = cloneCountToSet;

        private void CreateStateMachine() => stateMachine = new CloneManStateMachine(this);

        public override void UpdateEnemy()
        {
            if (currentState == EnemyState.DEACTIVE)
                return;

            stateMachine.Update();
        }

        public override void PlayerEnteredRange(PlayerController targetToSet)
        {
            base.PlayerEnteredRange(targetToSet);
            stateMachine.ChangeState(States.CHASING);
        }

        public override void PlayerExitedRange() => stateMachine.ChangeState(States.IDLE);

        public override void Die()
        {
            if (CloneCountLeft > 0)
                stateMachine.ChangeState(States.CLONING);
            base.Die();
        }

        public void Teleport() => stateMachine.ChangeState(States.TELEPORTING);

        public void SetDefaultColor(Color color) => enemyView.SetDefaultColor(color);

        public void ChangeColor(Color color) => enemyView.ChangeColor(color);
    }

}