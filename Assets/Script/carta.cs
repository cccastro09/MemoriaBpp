using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carta : MonoBehaviour

{
    [SerializeField]
    private Scenecontrol controller;

    [SerializeField]
    private GameObject Carta;
           

    public void OnMouseDown()
    {
        if (Carta.activeSelf)
        {
            Carta.SetActive(false);
            controller.CardRevealed(this);
           
        }

    }

    private int _id;

    public int id
    {

        get { return _id; }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
        
    }

    public void Unreveal () //funcion voltear
    {
        Carta.SetActive(true);
    }

}
