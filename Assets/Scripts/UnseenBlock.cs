using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class UnseenBlock : Block
{
    private SpriteRenderer _spriteRenderer;
    private bool _isVisible;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSpriteRenderer();
    }

    protected override void ApplyDamage()
    {
        if (_isVisible)
        {
            base.ApplyDamage();
        }
        else
        {
            _isVisible = true;
            UpdateSpriteRenderer();
        }
    }

    private void UpdateSpriteRenderer()
    {
        _spriteRenderer.enabled = _isVisible;
    }
}