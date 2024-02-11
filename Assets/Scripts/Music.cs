using UnityEngine;

public class Music : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlayMusic("Main");
    }
}
