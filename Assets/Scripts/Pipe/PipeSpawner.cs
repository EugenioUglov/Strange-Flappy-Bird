using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 1;
    [SerializeField] private Vector2 _yRandomRange = new Vector2(1f, -4f);

    [SerializeField] private PipeGroup _pipeMovement;

    private List<PipeGroup> _pipeGroups;
    private float _leftEdgeOutsideCamera;


    private void Awake()
    {
        _pipeGroups = new List<PipeGroup>();
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


    public void UpdatePipes()
    {
        if (_pipeGroups.Count == 0)
        {
            return;
        }

        foreach (var pipeMovement in _pipeGroups)
        {
            pipeMovement.MoveOnStep();
        }

        if (_pipeGroups[0].transform.position.x < _leftEdgeOutsideCamera)
        {
            Destroy(_pipeGroups[0].gameObject);
            _pipeGroups.RemoveAt(0);
        }
    }


    private void Spawn()
    {
        float randY = Random.Range(_yRandomRange.x, _yRandomRange.y);
        PipeGroup instantiatedPipeMovement = Instantiate(_pipeMovement, new Vector3(12, randY, 0), Quaternion.identity);

        _pipeGroups.Add(instantiatedPipeMovement);
    }
}
