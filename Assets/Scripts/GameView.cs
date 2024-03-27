using UnityEngine;

public class GameView : MonoBehaviour
{
    public GameModel Model { get; set; }

    public StartGameMenu startGameMenu;
    public LevelUpWindow levelUpWindow;
    public GameOverWindow gameOverWindow;
    public HudBar hudBar;

    public Player player;
    public WorldManager worldManager;
}
