using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Veriables

    public int _life;
    [SerializeField] private SpriteRenderer _block;
    [SerializeField] private Sprite[] _blockWithCracks;
    [SerializeField] private int _points;

    #endregion


    #region Events

    public static event Action<Block, int> OnDestroved;
    public static event Action<Block> OnCreated;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        OnCreated?.Invoke(this);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        ApplyDamage();
    }

    private void OnDestroy()
    {
        OnDestroved?.Invoke(this, _points);
    }

    #endregion


    #region Public methods

    protected virtual void ApplyDamage()
    {
        SetSprite();
        if (_life == 0)
        {
            Destroy(gameObject);
        }
    }

    #endregion


    #region Private methods

    public void SetSprite()
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

    #endregion
}