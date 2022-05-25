using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
[DefaultExecutionOrder(1000)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameoverUI;
    public TextMeshProUGUI scoreText;
    PlayerControllerV2 playerController;
    public GameObject player;

    [Header("Game Mechanics")]
    public int health;
    public int score;
    public int highScore;

    [Header("UI")]

    public TextMeshProUGUI highScoreText;
    public GameObject difficultyButtons;
    public GameObject mainMenuUI;
    public GameObject playUI;


    private void Awake()
        {
        if (Instance != null)
            {
            Destroy(gameObject);
            return;
            }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
        LoadScore();
        }

    private void Start()
        {
        playerController = GameObject.Find("Player").GetComponent<PlayerControllerV2>();
        player.SetActive(false);
        scoreText.text = "Score: " + score;
        //highScoreText.text = "" + highScore + "";
        }
    [System.Serializable] //Serve per convertire in JSON
    class SaveData
        {
        public int score;
        public int highScore;
        }

    void Update()
        {
        if (health == 0)
            {
            GameOver();
            }
        if (score >= highScore)
            {
            highScoreText.text = "Highscore" + highScore;
            }
        }
    public void UpLife(int healthToAdd)
        {
        health += healthToAdd;
        }

    public void DownLife(int healthToAdd)
        {
        health -= healthToAdd;
        }

    public void SaveScore()
        {
        SaveData data = new SaveData();
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

    public void SaveHighScore()
        {
        SaveData data = new SaveData();
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        }

    public void LoadScore()
        {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
            {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            score = data.score;
            }
        }

    public void LoadHighScore()
        {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
            {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            }
        }


    public void StartPress()
        {
        difficultyButtons.SetActive(true);
        }

    public void StartNew()
        {
        SceneManager.LoadScene(1);
        player.SetActive(true);
        playUI.SetActive(true);
        mainMenuUI.SetActive(false);

        }

    public void ReloadScene()
        {
        health = 3;
        score = 0;
        SceneManager.LoadScene(1);
        }

    public void UpdateScore(int scoreToAdd)
        {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        }


    public void GameOver()
        {
        playerController.gameOver = true;
        if (score > highScore)
            {
            highScore = score;
            }
        SaveScore();
        SaveHighScore();
        gameoverUI.SetActive(true);

        
        }


    public void Exit()
        {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

        }
    }
