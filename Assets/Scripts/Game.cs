using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private PipeSpawner _pipeSpawner;
    [SerializeField] private GameObject _clickToRestartGO;
    [SerializeField] private Bird _bird;
    [SerializeField] private UserInput _userInput;
    [SerializeField] private Parallax[] _parallaxes;

    
    private void OnEnable() 
    {
        _bird.OnDie += OnBirdDie;
    }

    private void OnDisable()
    {
        _bird.OnDie -= OnBirdDie;
    }

    private void Start()
    { 
        Application.targetFrameRate = 60;
        AudioManager.Instance.PlayMusic("Main");
    }

    private void Update()
    {
        if (_gameState.CurrentGameState == GameState.GameStateEnum.Playing)
        {
            foreach (var parallax in _parallaxes)
            {
                parallax.MoveOnStep();
            }
            
            _pipeSpawner.UpdatePipes();
        }
        else if (_gameState.CurrentGameState == GameState.GameStateEnum.Pause)
        {
            if (_userInput.IsGameRestart)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void OnBirdDie()
    { 
        _pipeSpawner.enabled = false;
        _clickToRestartGO.SetActive(true);
        _gameState.CurrentGameState = GameState.GameStateEnum.Pause;
    }
}
