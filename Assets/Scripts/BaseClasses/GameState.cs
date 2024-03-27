public abstract class GameState
{
    protected GameController Controller;

    public GameState(GameController controller)
    {
        Controller = controller;
    }
    
    public abstract void EnterState();
    public abstract void LeaveState();
}