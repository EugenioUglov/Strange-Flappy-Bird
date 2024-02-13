using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    public bool IsBirdJump { get; private set; }
    public bool IsGameRestart { get; private set; }


    void Update()
    {
        IsBirdJump = false;
        IsGameRestart = false;
        
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
        IsBirdJump = true;
        IsGameRestart = true;
    }
}
