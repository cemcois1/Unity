using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settilecode : MonoBehaviour
{
    public int a=5;
    [SerializeField] GameObject go;
    GameObject copy;
    
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            copy = Instantiate(go);
            copy.AddComponent<Tile>();
            copy.AddComponent<BoxCollider>();
        }
        //Grid x = new Grid();
        // x.createtiles(int  a, int b,vector2 başlangıçkonumu,vector3 karebüyüklüğü )

    }
    /*void createtiles(int a, int b, Vector2 başlangıçkonumu, Vector2 karebüyüklüğü)
    {
        this.matris[a,b];
        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                this.matris[i, j] = new GameObject();
                this.matris[i, j].AddComponent<Tile>();
            }
        }

    }*/

}
