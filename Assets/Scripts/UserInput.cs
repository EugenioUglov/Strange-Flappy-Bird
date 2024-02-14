using UnityEngine;

public class UserInput : MonoBehaviour
{
    public bool IsBirdJump { get; private set; }
    public bool IsGameRestart { get; private set; }


    public void ListenClick()
    {
        IsBirdJump = false;
        IsGameRestart = false;

        #if UNITY_STANDALONE_WIN || UNITY_EDITOR   
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            OnClick();
        }

        #elif UNITY_ANDROID //&& !UNITY_EDITOR
        if (Input.touchCount > 0)
        { 
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            { 
                OnClick();
            }
        }
        #endif
    }


    private void OnClick() 
    {
        IsBirdJump = true;
        IsGameRestart = true;
    }
}
