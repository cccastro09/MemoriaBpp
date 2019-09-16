using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cartaTres : MonoBehaviour

{
    [SerializeField]
    private GameObject CartaTres;

    public void OnMouseDown()
    {
        if (CartaTres.activeSelf)
        {
            CartaTres.SetActive(false);
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
}
