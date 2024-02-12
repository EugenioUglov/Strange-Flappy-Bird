using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private PipeSpawner _pipeSpawner;
    [SerializeField] private GameObject _clickToRestartGO;
    [SerializeField] private Bird _bird;

    
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


    private void OnBirdDie()
    { 
        _pipeSpawner.enabled = false;
        _clickToRestartGO.SetActive(true);
        _gameState.CurrentGameState = GameState.GameStateEnum.Pause;
    }
}
