
public class StartGameState : GameState
{
    public StartGameState(GameController controller) : base(controller)
    {
    }

    public override void EnterState()
    {
        Controller.View.startGameMenu.Show();
    }

    public override void LeaveState()
    {
        Controller.View.startGameMenu.Hide();
    }
}
