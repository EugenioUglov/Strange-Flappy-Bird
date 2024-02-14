using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMehPro;
    
    private int _number = 0;


    public void AddScore()
    {
        _number++;
        _textMehPro.text = _number.ToString();
    }
}
