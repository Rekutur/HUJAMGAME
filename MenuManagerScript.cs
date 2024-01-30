using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    public GameObject playScreen, pauseScreen, loseScreen, winScreen;

    public void ReturnToMain()
    {
        loseScreen.SetActive(false);
        DataManager.Instance.SaveData();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void PlayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        DataManager.Instance.credits = 0;
    }
    public void NextLevel()
    {
        DataManager.Instance.SaveData();
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
    public void PauseButton()
    {
        Time.timeScale = 0;
        playScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }
    public void UnPauseButton()
    {
        playScreen.SetActive(true);
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void HomeButton()
    {
        DataManager.Instance.SaveData();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Lose()
    {
        pauseScreen.SetActive(false);
        loseScreen.SetActive(true);
    }
    public void Win()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(false);
        winScreen.SetActive(true);
    }
    public void RollCredits()
    {
        DataManager.Instance.SaveData();
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }
}
