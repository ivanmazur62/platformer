
public class GameOverState : GameState
{
    public GameOverState(GameController controller) : base(controller)
    {
    }

    public override void EnterState()
    {
        Controller.View.gameOverWindow.Show();
    }

    public override void LeaveState()
    {
        Controller.View.hudBar.Hide();
        Controller.View.gameOverWindow.Hide();
        Controller.View.worldManager.Hide();
    }
}
