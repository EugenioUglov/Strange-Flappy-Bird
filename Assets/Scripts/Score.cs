using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreTextMehPro;
    
    private int _scoreNumber = 0;


    public void AddScore()
    {
        _scoreNumber++;
        _scoreTextMehPro.text = _scoreNumber.ToString();
    }
}
