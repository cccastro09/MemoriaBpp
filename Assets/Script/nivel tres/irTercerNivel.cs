using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class irTercerNivel : MonoBehaviour
{


    /* public void llamarNivel()
     {
         SceneManager.LoadScene("SampleScene");
     }*/
    // Start is called before the first frame update



    [System.Obsolete]
    void OnMouseDown()
    {
        //Debug.Log("click");
        Application.LoadLevel("TercerNivel");//paa cambiar de ecena revisar porque esta deprecado]\


    }
}
