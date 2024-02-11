using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 1;
    [SerializeField] private Vector2 _yRandomRange = new Vector2(1f, -4f);

    [SerializeField] private PipeMovement _pipeMovement;
    [SerializeField] private GameState _gameState;

    private List<PipeMovement> _pipeMovements;
    private float _leftEdgeOutsideCamera;


    private void Awake()
    {
        _pipeMovements = new List<PipeMovement>();
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), 0, _spawnRate);    
    }
    
    private void OnDisable() 
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Start()
    {
        _leftEdgeOutsideCamera = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 10;
    }

    private void Update()
    {
        if (_gameState.CurrentGameState == GameState.GameStateEnum.Pause || _pipeMovements.Count == 0)
        {
            return;
        }

        foreach (var pipeMovement in _pipeMovements)
        {
            pipeMovement.MoveStep();
        }

        if (_pipeMovements[0].transform.position.x < _leftEdgeOutsideCamera)
        {
            Destroy(_pipeMovements[0].gameObject);
            _pipeMovements.RemoveAt(0);
        }
    }


    private void Spawn()
    {
        float randY = Random.Range(_yRandomRange.x, _yRandomRange.y);
        PipeMovement instantiatedPipeMovement = Instantiate(_pipeMovement, new Vector3(12, randY, 0), Quaternion.identity);

        _pipeMovements.Add(instantiatedPipeMovement);
    }
}
