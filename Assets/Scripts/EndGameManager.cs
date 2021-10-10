using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    [Header("Backsound")]
    public GameObject backsound;

    private BallController ball;
    public GameObject endGamePanel;
    private SoundManager sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = FindObjectOfType<SoundManager>();
        ball = FindObjectOfType<BallController>();
        endGamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "milk" || other.gameObject.tag == "cereal" || other.gameObject.tag == "chocobar" || other.gameObject.tag == "grapesoda" || other.gameObject.tag == "potatochip")
        {
            ball.currentBallState = BallController.ballState.endGame;
            sound.over.Play();
            backsound.active = false;
            sound.gameover.Play();
            endGamePanel.SetActive(true);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
