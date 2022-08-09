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
            _pause.SetActive(IsPaused);
        }
    }

    #endregion


    #region Private methods

    public void TogglePause()
    {
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0 : 1;
    }

    #endregion
}