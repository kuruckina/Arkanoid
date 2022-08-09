using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Veriables

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector2 _startDirection;
    [SerializeField] private Pad _pad;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        _startDirection.x = (int) UnityEngine.Random.Range(-12f, 12f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3) _startDirection);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3) _rb.velocity);
    }

    #endregion


    #region Public methods

    public void StartMove()
    {
        _rb.velocity = _startDirection;
    }

    public void MoveWithPad()
    {
        _rb.velocity = new Vector2(_startDirection.x, 0);
        Vector3 padPosition = _pad.transform.position;
        Vector3 currentPosition = transform.position;
        currentPosition.x = padPosition.x;
        currentPosition.y = padPosition.y + 0.8f;
        transform.position = currentPosition;
    }

    #endregion
}