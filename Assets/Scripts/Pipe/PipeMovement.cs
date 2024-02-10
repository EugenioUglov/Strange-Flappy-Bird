using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    private bool _isMove = true;
    private float leftEdge;


    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 10;
    }

    private void Update()
    {
        if (transform.position.x < leftEdge)
        { 
            Destroy(gameObject);
        }
        if (_isMove)
        {
            transform.Translate(-_speed * Time.deltaTime, 0, 0);
        }
        else 
        {
            transform.Translate(0, 0, 0);
        }
    }


    public void Move()
    {
        _isMove = true;
    }

    public void Stop()
    {
        _isMove = false;
    }
}
