using System.Drawing;
using StatePattern.Main;
using StatePattern.StateMachine;

namespace StatePattern.Enemy
{
    public class CloningState<T> : IState where T : EnemyController
    {
        public EnemyController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;

        public CloningState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            CreateAClone();
            CreateAClone();
        }

        public void Update() { }

        public void OnStateExit() { }

        private void CreateAClone()
        {
            CloneManController clone = GameService.Instance.EnemyService.CreateEnemy(Owner.Data) as CloneManController;
            clone.SetCloneCount((Owner as CloneManController).CloneCountLeft - 1);
            clone.Teleport();
            clone.SetDefaultColor(UnityEngine.Color.red);
            clone.ChangeColor(UnityEngine.Color.blue);
            GameService.Instance.EnemyService.AddEnemy(clone);
        }
    }
}
