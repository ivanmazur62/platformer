using UnityEngine;

[RequireComponent(typeof(GameView))]
public sealed class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    
    public GameView View { get; private set; }
    private GameState _currentState;

    public bool IsPause { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        OnInitialize();
    }
    
    private void OnInitialize()
    {
        IsPause = true;
        View = GetComponent<GameView>();
        View.Model = new GameModel();
        View.Model.LoadPlayerStats();
        
        View.startGameMenu.startGameBtn.onClick.AddListener(StartGame);
        View.gameOverWindow.restartGameBtn.onClick.AddListener(StartGame);
        View.hudBar.OnStatShow += OnPauseResumeGame;

        ChangeState(new StartGameState(this));
    }

    private void OnDestroy()
    {
        View.startGameMenu.startGameBtn.onClick.RemoveListener(StartGame);
        View.gameOverWindow.restartGameBtn.onClick.RemoveListener(StartGame);
        View.hudBar.OnStatShow -= OnPauseResumeGame;
        View.player.OnDeath -= OnGameOver;
        View.player.OnUpdateStats -= OnUpdateStats;
    }

    private void ChangeState(GameState newState)
    {
        _currentState?.LeaveState();
        _currentState = newState;
        _currentState.EnterState();
    }
    
    public void InitializeGame()
    {
    }

    private void StartGame()
    {
        IsPause = false;
        ChangeState(new GameplayState(this));
        View.player.Initialize(View.Model.PlayerStats);
        View.player.OnDeath += OnGameOver;
        View.player.OnUpdateStats += OnUpdateStats;
        
        View.worldManager.StartGame();
    }

    private void OnUpdateStats(EntityStats obj)
    {
        View.Model.PlayerStats = obj;
        View.hudBar.SetupStats();
    }

    private void OnGameOver(EntityBase entity)
    {
        IsPause = true;
        ChangeState(new GameOverState(this));
    }
    
    private void OnPauseResumeGame()
    {
        if (_currentState is not PauseState)
            PauseGame();
        else
            ResumeGame();
    }
    
    private void PauseGame()
    {
        IsPause = true;
        ChangeState(new PauseState(this));
    }

    private void ResumeGame()
    {
        IsPause = false;
        ChangeState(new GameplayState(this));
    }

    public void SavePlayerStats()
    {
        View.Model.SavePlayerStats();
        View.hudBar.SetupStats();
    }
}
