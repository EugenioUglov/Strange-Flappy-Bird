using UnityEngine;

public class PipeGroup : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    
    public void MoveStep()
    { 
        transform.Translate(-_speed * Time.deltaTime, 0, 0);
    }
}
