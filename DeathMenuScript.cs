using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuScript : MonoBehaviour
{
    public static bool IsPlayerAlive = true;
    public GameObject deathMenu;
    
    void Start()
    {
        deathMenu.SetActive(false);   
    }

    
   private void Update()
    {
        CheckForPlayer();
        DeathMenu();
    }

     private void CheckForPlayer()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            IsPlayerAlive = false;
        }
        else
        {
            IsPlayerAlive = true;
        }  
    }

    private void DeathMenu()
    {
        if (IsPlayerAlive)
        {
            deathMenu.SetActive(false);
        }
        else
        {
            deathMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void TryAgain()
    {
        StartCoroutine(RestartGame());
    }

    public void BackToMenu()
    {
        StartCoroutine(ReloadMenu());
    }

    IEnumerator ReloadMenu()
    {
        yield return new WaitForEndOfFrame();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
        deathMenu.SetActive(false);
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForEndOfFrame();
        Time.timeScale = 1f; // Time scale'ý 1'e ayarla
        SceneManager.LoadScene("GameScene");
        deathMenu.SetActive(false); // Ölüm menüsünü kapat
    }
}
