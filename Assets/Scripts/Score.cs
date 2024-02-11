using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreTextMehPro;
    
    private int _scoreNumber;


    private void Start()
    {
        _scoreNumber = 0;
    }


    public void AddScore()
    {
        _scoreNumber++;
        _scoreTextMehPro.text = _scoreNumber.ToString();
    }
}
