using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Backsound")]
    public GameObject backsound;

    private SoundManager sound;

    void Start()
    {
        sound = FindObjectOfType<SoundManager>();
    }

    public void StartGame()
    {
        sound.click.Play();
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        sound.click.Play();
        backsound.active = false;
        Application.Quit();
    }
}
