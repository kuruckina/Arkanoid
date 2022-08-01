using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Unity lifecycle

    private int _life = 3;
    [SerializeField] private SpriteRenderer _blockWood;
    [SerializeField] private Sprite[] _blockWithCracks;

    //GameObject [] GlassBlocks;
    // private void Update()
    //{
    //   GlassBlocks =  GameObject.FindGameObjectsWithTag("GlassBlock");
    //}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (gameObject.tag == "GlassBlock")
        {
            Destroy(gameObject);
        }

        SetSprite();
        if (_life == 0)
        {
            Destroy(gameObject);
        }
    }

    #endregion


    #region Private methods

    private void SetSprite()
    {
        _life--;
        if (_life == 2)
        {
            _blockWood.sprite = _blockWithCracks[0];
        }
        else if (_life == 1)
        {
            _blockWood.sprite = _blockWithCracks[1];
        }
    }

    #endregion
}