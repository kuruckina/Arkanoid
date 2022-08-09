using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreLabel;
    [SerializeField] private TextMeshProUGUI _lifesLabel;

    public void SetLifeText(string text)
    {
        _lifesLabel.text = text;
    }

    public void SetScoreText(string text)
    {
        _scoreLabel.text = text;
    }
}