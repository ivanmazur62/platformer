public class GameplayState : GameState
{
    public GameplayState(GameController controller) : base(controller) { }
    
    public override void EnterState()
    {
        Controller.View.hudBar.Show();
        Controller.View.worldManager.Show();
    }

    public override void LeaveState()
    {
        
    }
}