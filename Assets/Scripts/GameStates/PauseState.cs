public class PauseState : GameState
{
    public PauseState(GameController controller) : base(controller)
    {
    }

    public override void EnterState()
    {
        Controller.View.levelUpWindow.Show();
    }

    public override void LeaveState()
    {
        Controller.View.levelUpWindow.Hide();
    }
}
