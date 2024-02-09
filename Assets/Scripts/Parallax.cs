using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float _animationSpeed = 1;

    private MeshRenderer _meshRenderer;

    private bool _isMove = true;


    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update() 
    {
        if (_isMove)
        {
            _meshRenderer.material.mainTextureOffset += new Vector2(_animationSpeed * Time.deltaTime, 0);
        }
        else 
        {
            transform.Translate(0, 0, 0);
        }
    }


    public void Move()
    { 
        _isMove = true;
    }
    
    public void Stop()
    { 
        _isMove = false;
    }
}
