using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class Ball : MonoBehaviour
{
    public event Action OnLosed;
    #region Veriables

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector2 _startDirection;
    [SerializeField] private Pad _pad;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        _startDirection.x = (int)UnityEngine.Random.Range(-12f, 12f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3) _startDirection);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3) _rb.velocity);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "bottom")
        {
            OnLosed?.Invoke();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
    }

    #endregion


    #region Public methods

    public void StartMove()
    {
        _rb.velocity = _startDirection;
    }

    public void MoveWithPad()
    {
        Vector3 padPosition = _pad.transform.position;
        Vector3 currentPosition = transform.position;
        currentPosition.x = padPosition.x;
        transform.position = currentPosition;
    }

    #endregion
}