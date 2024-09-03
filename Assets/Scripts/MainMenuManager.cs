using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public AudioSource audioSource;
    public void playGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void quit()
    {
        Application.Quit();   
    }

    public void playAudio()
    {
        audioSource.Play();
    }
}
