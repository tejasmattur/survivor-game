using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{

    public TMP_Text[] scoreTexts;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowLeaderBoard()
    {
        //int[] scores = GameOver.instance.scores;
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            try
            {
                string text = "Score: " + PlayerPrefs.GetInt(i.ToString()).ToString();
                scoreTexts[i].text = text;
            }
            catch
            {
                scoreTexts[i].text = "Score: 0";
            }
        }
        gameObject.SetActive(true);
    }

    public void HideLeaderBoard()
    {
        gameObject.SetActive(false);
    }
}
