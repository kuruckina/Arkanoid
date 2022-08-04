using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    #region Properties

    public bool IsPaused { get; private set; }

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    #endregion


    #region Private methods

    private void TogglePause()
    {
        IsPaused = !IsPaused;
        _pause.SetActive(IsPaused);
        Time.timeScale = IsPaused ? 0 : 1;
    }

    #endregion
}