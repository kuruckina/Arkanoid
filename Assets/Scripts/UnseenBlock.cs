using UnityEngine;

public class UnseenBlock : Block
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        SetSprite();
        if (_life == 0)
        {
            Destroy(gameObject);
        }
    }
}