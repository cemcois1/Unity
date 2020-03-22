using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tıklandı : MonoBehaviour
{
    Color color=Color.red;
    private void OnMouseUp()
    {
        print("bir şeyler oluyor2");
        gameObject.GetComponent<MeshRenderer>().material.color= color ;

    }
}
