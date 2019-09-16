﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Scenecontrol2 : MonoBehaviour
{

    public const int griRows = 2;
    public const int griCols = 4;
    public const float offsetX = 3f;
    public const float offeseY = 3f;

    public AudioClip carta, tema1;
    AudioSource sonido;

    //////copiar al siguiente nivel
    public GameObject aux;
    public SonidoFrutaDos sss;
    //////

    [SerializeField]
    //private carta originalCard;
    public cartaDos originalCard;
    [SerializeField]
    //private Sprite[] images;
    public Sprite[] images;


    public int score = 0;

    private void Start()
    {

        /////copiar al siguiente nivel
        aux = GameObject.Find("Auxiliar");
        sss = new SonidoFrutaDos();
        /////


        Vector3 startPos = originalCard.transform.position;
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3};
        //randon del array
        numbers = ShuffleArray(numbers);

        for (int i = 0; i < griCols; i++)
        {
            for (int j = 0; j < griRows; j++)
            {
                cartaDos card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;

                }
                else
                {

                    card = Instantiate(originalCard) as cartaDos;

                }

                int index = j * griCols + i;
                int id = numbers[index];
                card.ChangeSprite(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = (offeseY * j) + startPos.y;

                card.transform.position = new Vector3(posX, posY, startPos.z);
            }

        }

    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {

            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;

        }

        return newArray;

    }

    private cartaDos _firstReveaLed;
    private cartaDos _sconReveaLed;

    private int _score = 0;

    [SerializeField]
    private TextMesh scoreLabel;

    public bool canReveal
    {
        get { return _sconReveaLed = null; }

    }

    public void CardRevealed(cartaDos card)
    {
        if
        (_firstReveaLed == null)
        {

            if (_firstReveaLed = card)
            {
                sonido.clip = carta;
                sonido.Play();

            };




        }
        else
        {

            _sconReveaLed = card;
            StartCoroutine(CheckedMatch());

        }
    }
    private IEnumerator CheckedMatch()
    {
        if (_firstReveaLed.id == _sconReveaLed.id)
        {

            ////// copiar al siguiente nivel sonido
            string im = _sconReveaLed.GetComponent<SpriteRenderer>().sprite.ToString();
            string[] et = im.Split(' ');
            string n_fru = et[0];
            //Debug.Log(n_fru);//para mostrar el nombre de la fruta
            sss = aux.GetComponent<SonidoFrutaDos>();
            sss.nombrar_fruta(n_fru);
            ///////



            _score++;
            scoreLabel.text = "Puntaje: " + _score;
            if (_score == 4)
            {
                //tiempo de espera para cambio de escena ----> copiar al siguiente nivel
                yield return new WaitForSeconds(2.0f);
                SceneManager.LoadScene("ganarSegundoNivel");
            }

        }
        else
        {

            yield return new WaitForSeconds(0.5f); //tiempo que espera voltear carta cuando esta mal

            Debug.Log(_firstReveaLed.id);

            _firstReveaLed.Unreveal();
            _sconReveaLed.Unreveal();
        }

        _firstReveaLed = null;
        _sconReveaLed = null;

    }

    void cardCoparion(List<int> c)
    {

    }

}

