public abstract class State
{
    protected BeingBehavior sub; // subject of the state

    public abstract void Tick();

    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

    public State(BeingBehavior sub_)
    {
        sub = sub_;
    }
}