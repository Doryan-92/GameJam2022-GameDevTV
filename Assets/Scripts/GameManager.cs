using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerControllerV2 playerController;
    public int health;
    public int score;
    public int highScore;
    public TextMeshProUGUI scoreText;
    public GameObject gameoverText;
    public GameObject gameover2Text;

    public static GameManager Instance;

    private void Awake()
        {
        if (Instance != null)
            {
            Destroy(gameObject);
            return;
            }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        }
   
    [System.Serializable] //Serve per convertire in JSON
    class SaveData
        {
        public int score;
        }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        playerController = GameObject.Find("Player").GetComponent<PlayerControllerV2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
            {
            GameOver();
            }
    }

    public void UpdateScore(int scoreToAdd)
        {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        }

    public void UpLife(int healthToAdd)
        {
        health += healthToAdd;
        }

    public void DownLife(int healthToAdd)
        {
        health -= healthToAdd;
        }

public void GameOver()
        {
        playerController.gameOver = true;
        if (score > highScore)
            {
            highScore = score;
            }
        gameoverText.SetActive(true);
        gameover2Text.SetActive(true);
        }
    }
