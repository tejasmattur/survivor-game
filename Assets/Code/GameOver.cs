using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

 /*   private void Start()
    {
        gameObject.SetActive(false);
    }*/
    // Start is called before the first frame update
    public void gameOver()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("BasicMap");
    }
}
