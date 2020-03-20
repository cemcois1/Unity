using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settilecode : MonoBehaviour
{
   public GameObject go;
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            Instantiate(go);

        }

    }

}
