using UnityEngine;
using System;

public class BirdMovement : MonoBehaviour
{
    public static Action OnMove;

    [SerializeField]
    private float _force = 4;

    private Rigidbody2D _birdRigidbody;


    private void Start()
    {
        _birdRigidbody = GetComponent<Rigidbody2D>();
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
        _birdRigidbody.velocity = Vector2.up * _force;
        OnMove?.Invoke();
    }
}
