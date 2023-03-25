using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOver : MonoBehaviour
{

    public TMP_Text coinText;
    public TMP_Text timeText;
    private void Start()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    public void gameOver()
    {
        coinText.text = "Coins Collected:" + PlayerController.instance.coinCount;
        timeText.text = "Time Survived: " + GameController.instance.timerText;
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
}
