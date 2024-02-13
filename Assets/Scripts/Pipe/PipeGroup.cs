using UnityEngine;

public class PipeGroup : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    
    public void MoveOnStep()
    { 
        transform.Translate(-_speed * Time.deltaTime, 0, 0);
    }
}
