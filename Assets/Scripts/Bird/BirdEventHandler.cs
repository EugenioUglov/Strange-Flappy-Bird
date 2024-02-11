using UnityEngine;

public class BirdEventHandler : MonoBehaviour
{
    [SerializeField] private BirdCollision _birdCollision;
    [SerializeField] private BirdMovement _birdMovement;
    [SerializeField] private GameState _gameState;
    [SerializeField] private PipeSpawner _pipeSpawner;
    [SerializeField] private GameObject _clickToRestartGO;


    private void OnEnable() 
    {
        _birdCollision.OnDie += OnBirdDie;
        _birdMovement.OnJump += OnBirdJump;
    }

    private void OnDisable() 
    {
        _birdCollision.OnDie -= OnBirdDie;
        _birdMovement.OnJump -= OnBirdJump;
    }
    

    private void OnBirdDie()
    {
        _pipeSpawner.enabled = false;
        _birdMovement.enabled = false;
        _birdCollision.enabled = false;
        _clickToRestartGO.SetActive(true);
        _gameState.CurrentGameState = GameState.GameStateEnum.Pause;
    }
    
    private void OnBirdJump()
    {
        AudioManager.Instance.PlaySFX("WingFlap");
    }
}
