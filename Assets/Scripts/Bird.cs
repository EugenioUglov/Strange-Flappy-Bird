using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Bird : MonoBehaviour
{
    public Action OnDie;

    [SerializeField] private float _force = 4;

    [SerializeField] private Sprite _deathBird;
    [SerializeField] private GameObject _bloodEffect;
    [SerializeField] private GameObject _blood;
    [SerializeField] private Score _score;

    private bool _isDead = false;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;


    private void Awake() 
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(_blood, transform.position, Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));

        if (_isDead) return;

        if (
            collision.collider.GetComponent(typeof(Pipe)) != null ||
            collision.collider.GetComponent(typeof(Ground)) != null
        )
        {
            _isDead = true;
            AudioManager.Instance.PlaySFX("Punch");
            AudioManager.Instance.PlayMusic("Sad");
            _bloodEffect.SetActive(true);
            _spriteRenderer.sprite = _deathBird;
            _rigidbody.freezeRotation = false;
            _animator.enabled = false;
 
            OnDie?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (_isDead) return;

        if (collider.GetComponent(typeof(PipeEnterZone)) != null)
        {
            _score.AddScore();
        }
    }
    
    public void Jump()
    { 
        _rigidbody.velocity = Vector2.up * _force;
        AudioManager.Instance.PlaySFX("WingFlap");
    }
}
