using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenuScript : MonoBehaviour
{
    public GameObject winUI;
    void Start()
    {
        winUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain()
    {
        StartCoroutine(RestartGame());
    }

    public void ReturnToMenu()
    {
        StartCoroutine(ReturnToMen());
    }

    IEnumerator ReturnToMen()
    {
        yield return new WaitForEndOfFrame();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
        winUI.SetActive(false);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForEndOfFrame();
        Time.timeScale = 1f; 
        SceneManager.LoadScene("GameScene");
        winUI.SetActive(false); 
    }
}
