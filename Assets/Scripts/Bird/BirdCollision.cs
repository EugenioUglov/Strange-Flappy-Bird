using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BirdCollision : MonoBehaviour
{
    public Action OnDie;

    [SerializeField] private Sprite _deathBird;
    [SerializeField] private GameObject _bloodEffect;
    [SerializeField] private GameObject _blood;
    [SerializeField] private Score _score;

    private bool _isDead = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(_blood, transform.position, Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));

        if (_isDead) return;

        if (
            collision.collider.GetComponent(typeof(PipeTag)) != null ||
            collision.collider.GetComponent(typeof(GroundTag)) != null
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
