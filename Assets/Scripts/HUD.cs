using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;
    private int _lifes = 3;

    private void Start()
    {
        FindObjectOfType<Ball>().OnLosed += SetLifeText;
    }

    private void SetLifeText()
    {
        _lifes--;
        _label.text = $"Lifes: {_lifes}";
        if (_lifes == 0)
        {
        }
    }

    public void SetScoreText(string text)
    {
        _label.text = text;
    }
}