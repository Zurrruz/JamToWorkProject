using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverWindow;

    void Start()
    {
        _gameOverWindow.SetActive(false);
        HealthControl._damageReceived += CheckHealthPlayer;
    }
    private void OnDestroy()
    {
        HealthControl._damageReceived -= CheckHealthPlayer;
    }

    private void CheckHealthPlayer(float currentHealth)
    {
        if (currentHealth <= 0)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            _gameOverWindow.SetActive(true);
        }
    }

    public void RestartGameButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
