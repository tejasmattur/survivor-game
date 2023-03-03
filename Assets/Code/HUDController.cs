using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider Slider;
    public Color Low;
    public Color High;
    float MAX = 10;
    protected GameObject player;
    void Start()
    {
        Slider.maxValue = MAX;
        Slider.value = 0;
        player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        showExp();
    }

    public void showExp()
    {
        Slider.maxValue = MAX;
        Slider.value = player.GetComponent<PlayerController>().coinCount;

        Debug.Log("Slider Value" + Slider.value);

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);
    }
}
