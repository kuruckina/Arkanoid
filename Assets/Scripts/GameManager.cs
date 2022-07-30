using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Veriables

    [SerializeField] private Ball _ball;
    private bool _isStarted;

    #endregion


    #region Unity Lifecycle

    private void Update()
    {
        if (_isStarted)
        {
            return;
        }

        _ball.MoveWithPad();

        if (Input.GetMouseButtonDown(0))
        {
            StartBall();
        }
    }

    #endregion


    #region Private methods

    private void StartBall()
    {
        _isStarted = true;
        _ball.StartMove();
    }

    #endregion
}