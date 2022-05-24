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

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Mechanics")]
    public int health;
    public int score;
    public static int highScore;

    [Header("UI")]

    public TextMeshProUGUI highScoreText;
    public GameObject difficultyButtons;


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
        difficultyButtons = GameObject.Find("Difficulty Buttons");
        highScoreText = FindObjectOfType<TextMeshProUGUI>();
        highScoreText.text = "" + highScore + "";
        }
    [System.Serializable] //Serve per convertire in JSON
    class SaveData
        {
        public int score;
        public int highScore;
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
        difficultyButtons.SetActive(false);
        SceneManager.LoadScene(1);
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
