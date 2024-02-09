using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreTextMehPro;
    
    private int scoreNumber;


    private void Start()
    {
        scoreNumber = 0;
    }


    public void AddScore(int additionalScore = 1)
    {
        scoreNumber++;
        _scoreTextMehPro.text = scoreNumber.ToString();
    }
}
