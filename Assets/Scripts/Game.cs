using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private PipeSpawner _pipeSpawner;
    [SerializeField] private GameObject _clickToRestartGO;
    [SerializeField] private GameObject _bird;


    private void OnEnable() 
    {
        BirdCollision.OnDie += OnBirdDie;
        BirdMovement.OnMove += OnBirdMove;
    }

    private void OnDisable() 
    {
        BirdCollision.OnDie -= OnBirdDie;
        BirdMovement.OnMove -= OnBirdMove;
    }

    private void Awake() 
    {
        Application.targetFrameRate = 60;
        AudioManager.Instance.PlayMusic("Main");
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            OnClick();
        }

        if (Input.touchCount > 0)
        { 
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            { 
                OnClick();
            }
        }
    }
    

    private void OnClick() 
    {
        if (_gameState.CurrentGameState == GameState.GameStateEnum.Pause)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnBirdDie()
    {
        PipeMovement[] pipeMovements = FindObjectsOfType (typeof(PipeMovement)) as PipeMovement[];

        Parallax[] parallaxes = FindObjectsOfType (typeof(Parallax)) as Parallax[];


        foreach (PipeMovement pipeMovement in pipeMovements)
        {
            pipeMovement.Stop();
        }

        foreach (Parallax parallax in parallaxes)
        {
            parallax.Stop();
        }

        _pipeSpawner.enabled = false;
        _bird.GetComponent<BirdMovement>().enabled = false;
        _bird.GetComponent<BirdCollision>().enabled = false;
        _clickToRestartGO.SetActive(true);
        _gameState.CurrentGameState = GameState.GameStateEnum.Pause;
    }
    
    private void OnBirdMove()
    {
        AudioManager.Instance.PlaySFX("WingFlap");
    }
}
