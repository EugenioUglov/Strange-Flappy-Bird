using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float _animationSpeed = 1;

    private MeshRenderer _meshRenderer;


    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }


    public void MoveOnStep() 
    {
        _meshRenderer.material.mainTextureOffset += new Vector2(_animationSpeed * Time.deltaTime, 0);
    }
}
