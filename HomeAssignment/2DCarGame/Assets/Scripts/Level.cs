using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delay = 2f;

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().ResetGame(); 
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void QuitGame()
    {
        //will only work on EXE game
        Application.Quit();
    }

    IEnumerator WinningScene()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameWin");
    }

    public void LoadGameWin()
    {
        StartCoroutine(WinningScene());
    }
}
