using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInput : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private BirdMovement _birdMovement;


    void Update()
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
        else 
        {
            _birdMovement.Jump();
        }
    }
}
