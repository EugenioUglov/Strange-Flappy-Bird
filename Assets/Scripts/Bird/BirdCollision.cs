using UnityEngine;
using System;

public class BirdCollision : MonoBehaviour
{
    public static Action OnDie;

    [SerializeField] private Sprite _deathBird;
    [SerializeField] private GameObject _bloodEffect;
    [SerializeField] private GameObject _blood;
    [SerializeField] private Score _score;

    private bool _isDead = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isDead) return;

        Instantiate(_blood, transform.position, transform.rotation);

        if (
            collision.collider.GetComponent(typeof(Pipe)) != null ||
            collision.collider.GetComponent(typeof(Ground)) != null
        )
        {
            _isDead = true;
            AudioManager.Instance.PlaySFX("Punch");
            AudioManager.Instance.PlayMusic("Sad");
            _bloodEffect.SetActive(true);
            GetComponent<SpriteRenderer>().sprite = _deathBird;
            GetComponent<Rigidbody2D>().freezeRotation = false;
            GetComponent<Animator>().enabled = false;

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
}
