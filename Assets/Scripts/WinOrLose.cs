using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinOrLose : MonoBehaviour
{
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _nextLevelButton;

    private void Start()
    {
        _restartButton.onClick.AddListener(ReloadSceen);
        _nextLevelButton.onClick.AddListener(NextLevel);
    }

    private void NextLevel()
    {
        FindObjectOfType<LevelManager>().LoadLevel();
        FindObjectOfType<PauseManager>().TogglePause();
        FindObjectOfType<GameManager>().ChangeIsStarted();
        FindObjectOfType<Ball>().MoveWithPad();
        _winScreen.SetActive(false);
    }

    private void ReloadSceen()
    {
        FindObjectOfType<PauseManager>().TogglePause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void PerforLose()
    {
        _loseScreen.SetActive(true);
        FindObjectOfType<PauseManager>().TogglePause();
    }

    public void PerforWin()
    {
        _winScreen.SetActive(true);
        FindObjectOfType<PauseManager>().TogglePause();
    }
}