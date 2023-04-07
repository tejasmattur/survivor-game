using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOver : MonoBehaviour
{
    public static GameOver instance;
    //public string scoreId;
    public TMP_Text coinText;
    public TMP_Text timeText;
    public TMP_Text scoreText;
    public int score;
    public int[] scores = new int[7];

    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);

        //uncomment this to clear local stored scores
        //PlayerPrefs.DeleteAll();

        if (!PlayerPrefs.HasKey("0"))
        {
            for (int i = 0; i < 7; i++)
            {
                PlayerPrefs.SetInt(i.ToString(), 0);
            }
            PlayerPrefs.Save();
        }
    }
    // Start is called before the first frame update
    public void gameOver()
    {
        coinText.text = "Coins Collected:" + PlayerController.instance.coinCount;
        timeText.text = "Time Survived: " + GameController.instance.timerText;
        score = (int)GameController.instance.endTime * 2 + PlayerController.instance.coinCount;
        scoreText.text = "Score: " + score.ToString();
        //scoreId = System.Guid.NewGuid().ToString();
        //PlayerPrefs.SetInt("0", score);
        PushScoreToLeaderboard();

        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        GameController.instance.Reset();
        SceneManager.LoadScene("BasicMap");
        Debug.Log("Game Restarted");
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void PushScoreToLeaderboard()
    {
        bool isHighScore = false;
        int indexToReplace = -1;
        for (int i = 0; i < 7; i++)
        {
            if (score > PlayerPrefs.GetInt(i.ToString()))
            {
                isHighScore = true;
                indexToReplace = i;
                break;
            }
        }

        // Only update scores and UI if new score is a high score
        if (isHighScore)
        {
            for (int i = 6; i >= indexToReplace; i--)
            {
                PlayerPrefs.SetInt((i + 1).ToString(), PlayerPrefs.GetInt(i.ToString()));
            }
            // Add new score to array
            PlayerPrefs.SetInt(indexToReplace.ToString(), score);
        }
        PlayerPrefs.Save();
    }

}
