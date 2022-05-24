using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayManager : MonoBehaviour
{
    public GameObject gameoverUI;
    public TextMeshProUGUI scoreText;
    PlayerControllerV2 playerController;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.score = 0;
        scoreText.text = "Score: " + GameManager.Instance.score;
        playerController = GameObject.Find("Player").GetComponent<PlayerControllerV2>();
        }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.health == 0)
            {
            GameOver();
            }
        }

    public void UpdateScore(int scoreToAdd)
        {
        GameManager.Instance.score += scoreToAdd;
        scoreText.text = "Score: " + GameManager.Instance.score;
        }


    public void GameOver()
        {
        playerController.gameOver = true;
        if (GameManager.Instance.score > GameManager.highScore)
            {
            GameManager.highScore = GameManager.Instance.score;
            }
        GameManager.Instance.SaveScore();
        GameManager.Instance.SaveHighScore();
        gameoverUI.SetActive(true);
        }

    public void ReturnMenu()
        {
        SceneManager.LoadScene(0);
        }

    public void UpLife(int healthToAdd)
        {
        GameManager.Instance.health += healthToAdd;
        }

    public void DownLife(int healthToAdd)
        {
        GameManager.Instance.health -= healthToAdd;
        }
    }
