using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 1;
    [SerializeField] private Vector2 _yRandomRange = new Vector2(1f, -4f);

    [SerializeField] private GameObject _pipeGroupPrefab;
    [SerializeField] private GameState _gameState;

    private List<GameObject> _instantiatedPipeGroups;
    private float _leftEdgeOutsideCamera;


    private void Awake()
    {
        _instantiatedPipeGroups = new List<GameObject>();
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
        if (_gameState.CurrentGameState == GameState.GameStateEnum.Pause || _instantiatedPipeGroups.Count == 0)
        {
            return;
        }

        foreach (var pipeGroup in _instantiatedPipeGroups)
        {
            pipeGroup.GetComponent<PipeMovement>().MoveStep();
        }

        if (_instantiatedPipeGroups[0].transform.position.x < _leftEdgeOutsideCamera)
        { 
            Destroy(_instantiatedPipeGroups[0]);
            _instantiatedPipeGroups.RemoveAt(0);
        }
    }


    private void Spawn()
    {
        float randY = Random.Range(_yRandomRange.x, _yRandomRange.y);
        GameObject instantiatedPipeGroup = Instantiate(_pipeGroupPrefab, new Vector3(12, randY, 0), Quaternion.identity);

        _instantiatedPipeGroups.Add(instantiatedPipeGroup);
    }
}
