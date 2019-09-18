using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl3 : MonoBehaviour
{
    public const int griRows = 2;
    public const int griCols = 6;
    public const float offsetX = 2.5f;
    public const float offeseY = 2.5f;

    [SerializeField]
    public cartaTres originalCard;

    [SerializeField]
    public Sprite[] images;

    public int score = 0;

    private void Start()
    {
        Vector3 startPos = originalCard.transform.position;
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4,5,5};

        numbers = ShuffleArray(numbers);

        for (int i = 0; i < griCols; i++)
        {
            for (int j = 0; j < griRows; j++)
            {
                cartaTres card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;

                }
                else
                {
                    card = Instantiate(originalCard) as cartaTres;
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


    private int[] ShuffleArray (int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i <newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;

        }

        return newArray;
    }


    private cartaTres _firstReveaLed;
    private cartaTres _sconReveaLed;

    private int _score = 0;
    [SerializeField]
    private TextMesh scoreLabel;

    public bool canReveal
    {
        get { return _sconReveaLed = null;  }
    }

    public void CardRevealed (cartaTres card)
    {
        if
            (_firstReveaLed == null)
        {
            _firstReveaLed = card;
        }
        else
        {
            _sconReveaLed = card;
            StartCoroutine(CheckedMatch());
        }
    }

    private IEnumerator CheckedMatch()
        {
            if (_sconReveaLed.id == _sconReveaLed.id)
            {
                _score++;
                scoreLabel.text = "Puntaje: " + _score;
              
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
                _firstReveaLed.Unreveal();
                _sconReveaLed.Unreveal();

            }


            _firstReveaLed = null;
            _sconReveaLed = null;

        }

        void cardCoparion(List<int> c) { }
    
 }

