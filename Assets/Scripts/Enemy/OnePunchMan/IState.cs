namespace StatePattern.Enemy
{
    public interface IState
    {
        public OnePunchManController Owner { get; set; }
        public void OnStateEnter();
        public void Update();
        public void OnStateExit();
    }
}