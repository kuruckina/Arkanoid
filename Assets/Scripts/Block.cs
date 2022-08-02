using System;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Unity lifecycle

    [SerializeField] private int _life;
    [SerializeField] private SpriteRenderer _block;
    [SerializeField] private Sprite[] _blockWithCracks;
    [SerializeField] private int _points;

    public TextMeshProUGUI ScoreLabel;

    int _score;

    private void Start()
    {
        _score = 0;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        SetSprite();
        if (_life == 0)
        {
            Destroy(gameObject);
            SetScoreText();
            
        }
    }

    #endregion


    #region Private methods

    private void SetSprite()
    {
        _life--;
        if (_life == 2)
        {
            _block.sprite = _blockWithCracks[0];
        }
        else if (_life == 1)
        {
            _block.sprite = _blockWithCracks[1];
        }
    }

    private void SetScoreText()
    {
        _score = _score + _points;
        Debug.Log(_score);
        ScoreLabel.text = $"Score: {_score}";
    }

    #endregion
}