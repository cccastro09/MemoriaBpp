using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    Image timbeBar;
    //public float maxTime = 5f;
    public float maxTime;
    float timeLeft;
    public GameObject timeUpText;

    private void Awake()
    {
        maxTime = 20f;
    }
    void Start()
    {
        timeUpText.SetActive(false);
        timbeBar = GetComponent<Image>();
        timeLeft = maxTime;

    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timbeBar.fillAmount = timeLeft / maxTime;
            Time.timeScale = 1;

        }
        else
        {
            timeUpText.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
