using UnityEngine;
using System;

public class BottomWall : MonoBehaviour
{
    public event Action OnLosed;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Ball")
        {
            OnLosed?.Invoke();
        }
    }
}