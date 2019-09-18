﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class timerTres : MonoBehaviour
{
    public Transform Carga;
    public Transform TextIndicador;
    public Transform TextCargar;

    [SerializeField]
    private float Cantidad = 0;

    [SerializeField]
    private float Velocidad = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Cantidad < 500)
        {
            Cantidad += Velocidad * Time.deltaTime;
            TextIndicador.GetComponent<Text>().text = ((int)Cantidad).ToString() + "";
            TextCargar.gameObject.SetActive(true);
        }
        else
        {
            TextCargar.gameObject.SetActive(false);
            TextIndicador.GetComponent<Text>().text = "fin";
            SceneManager.LoadScene("perderTercerNivel");

        }

        Carga.GetComponent<Image>().fillAmount = Cantidad / 500;
    }
}

