using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*tilelar adında dizi oluşturuluyor ve ekrandan girilen değerlere göre üretiliyor
 * 
 * 
 * 
 * 
 */

public class tileoluşturmakodu : MonoBehaviour
{
    public int sizex, sizey;
    GameObject tmp;

    [SerializeField] GameObject tile;
    void Start()
    {
        GameObject Grid = new GameObject("Grid");
        GameObject[,] tilelar = new GameObject[sizex, sizey];

        for (int i = 0; i < sizex; i++)//tileları üretip kaydediyor koordinatlarını
        {
            for (int j = 0; j < sizey; j++)
            {

                tmp = Instantiate(tile, new Vector3(i, -j), Quaternion.identity,Grid.transform);
                tilelar[i, j] = tmp;
                tmp.name = i.ToString() + j;
                tmp.AddComponent<Tile>();
            }

        }

    }

}
