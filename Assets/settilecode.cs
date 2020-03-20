using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settilecode : MonoBehaviour
{
   public GameObject go;
    GameObject copy;
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            copy= Instantiate(go);
            copy.AddComponent<Tile>();
            copy.AddComponent<BoxCollider>();
        }

    }

}
