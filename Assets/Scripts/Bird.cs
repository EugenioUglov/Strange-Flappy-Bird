using UnityEngine;
using Random = UnityEngine.Random;

public class Bird : MonoBehaviour
{
    [SerializeField] private float _force = 4;

    [SerializeField] private Sprite _deathBird;
    [SerializeField] private GameObject _bloodEffect;
    [SerializeField] private GameObject _blood;
    [SerializeField] private Score _score;
    [SerializeField] private GameState _gameState;
    [SerializeField] private PipeSpawner _pipeSpawner;
    [SerializeField] private GameObject _clickToRestartGO;

    private bool _isDead = false;
    private Rigidbody2D _birdRigidbody;


    private void Start()
    {
        _birdRigidbody = GetComponent<Rigidbody2D>();
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
            GetComponent<SpriteRenderer>().sprite = _deathBird;
            GetComponent<Rigidbody2D>().freezeRotation = false;
            GetComponent<Animator>().enabled = false;
            _pipeSpawner.enabled = false;
            _clickToRestartGO.SetActive(true);
            _gameState.CurrentGameState = GameState.GameStateEnum.Pause;
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
        _birdRigidbody.velocity = Vector2.up * _force;
        AudioManager.Instance.PlaySFX("WingFlap");
    }
}
