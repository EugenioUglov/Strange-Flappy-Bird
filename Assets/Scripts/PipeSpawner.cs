using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pipes;
    [SerializeField] private float _spawnRate = 1;
    

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), _spawnRate, _spawnRate);    
    }
    private void OnDisable() 
    {
        CancelInvoke(nameof(Spawn));
    }


    private void Spawn()
    {
        float randY = Random.Range(1f, -4f);
        GameObject pipeGroupInstantiated = Instantiate(_pipes, new Vector3(12, randY, 0), Quaternion.identity);
    }
}
