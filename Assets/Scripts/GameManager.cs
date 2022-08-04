using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    #region Veriables

    [SerializeField] private Ball _ball;
    private bool _isStarted;

    #endregion


    #region Properties

    public int Score { get; private set; }

    #endregion


    #region Unity Lifecycle

    private void Start()
    {
        FindObjectOfType<LevelManager>().OnAllBlocksDestroyed += PerforWin;
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelManager>().OnAllBlocksDestroyed -= PerforWin;
    }

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


    #region Public methods

    public void PerforWin()
    {
        Debug.Log("WIIIN");
    }

    public void AddScore(int point)
    {
        Score += point;
        FindObjectOfType<HUD>().SetScoreText($"Score: {Score}");
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