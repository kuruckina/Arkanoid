using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Veriables

    [SerializeField] private Ball _ball;
    [SerializeField] private int _lifes;
    private bool _isStarted;

    #endregion


    #region Properties

    public int Score { get; private set; }

    #endregion


    #region Unity Lifecycle

    private void Start()
    {
        FindObjectOfType<HUD>().SetScoreText($"Score: {Score}");
        FindObjectOfType<HUD>().SetLifeText($"Lifes: {_lifes}");
        FindObjectOfType<LevelManager>().OnAllBlocksDestroyed += Win;
        FindObjectOfType<BottomWall>().OnLosed += LoseLifes;
    }

    private void OnDestroy()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if (levelManager != null)
        {
            levelManager.OnAllBlocksDestroyed -= Win;
        }

        BottomWall bottomWall = FindObjectOfType<BottomWall>();
        if (bottomWall != null)
        {
            FindObjectOfType<BottomWall>().OnLosed -= LoseLifes;
        }
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

    public void Win()
    {
        if (FindObjectOfType<WinOrLose>())
            FindObjectOfType<WinOrLose>().PerforWin();
    }

    public void AddScore(int point)
    {
        Score += point;
        if (FindObjectOfType<HUD>())
        {
            FindObjectOfType<HUD>().SetScoreText($"Score: {Score}");
        }
    }

    public void ChangeIsStarted()
    {
        _isStarted = !_isStarted;
    }

    #endregion


    #region Private methods

    private void LoseLifes()
    {
        _lifes--;
        FindObjectOfType<HUD>().SetLifeText($"Lifes: {_lifes}");
        ChangeIsStarted();

        if (_lifes == 0)
        {
            FindObjectOfType<WinOrLose>().PerforLose();
        }
    }

    private void StartBall()
    {
        ChangeIsStarted();
        _ball.StartMove();
    }

    #endregion
}