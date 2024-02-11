using UnityEngine;
using System;

public class BirdMovement : MonoBehaviour
{
    public Action OnJump;

    [SerializeField]
    private float _force = 4;

    private Rigidbody2D _birdRigidbody;


    private void Start()
    {
        _birdRigidbody = GetComponent<Rigidbody2D>();
    }
    

    public void Jump()
    { 
        _birdRigidbody.velocity = Vector2.up * _force;
        OnJump?.Invoke();
    }
}
