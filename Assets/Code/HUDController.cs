using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public static HUDController instance;
    // Start is called before the first frame update
    public Image expImage;
    public TMP_Text levelText;

    public float maxExp;
    public float curExp;
    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        showExp();
    }
    void Start()
    {
        curExp = 0;
        maxExp = 1f;
        levelText.text = "1";
    }


    public void showExp()
    {

        if (curExp >= maxExp)
        {
            curExp = 0;
            maxExp += Mathf.RoundToInt(maxExp * .65f);

            // Increase level when exp is full
            GameController.instance.level += 1;
            levelText.text = GameController.instance.level.ToString();
        }

        expImage.fillAmount = curExp / maxExp;
    }
}
