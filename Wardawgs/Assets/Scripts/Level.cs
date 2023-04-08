using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private float delayInSeconds = 2f;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadGameScene()
    {
        FindObjectOfType<GameSession>().ResetScore();
        SceneManager.LoadScene("Game");
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }
}
