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
    public float offsetX , offsetY , scale;
    public Material material;

    private GameObject tmp;
    void Start()
    {
        Dictionary<string, inTile> refDic = new Dictionary<string, inTile>();  //Object Pooling
        
        inTile refInTile = new inTile();
        refInTile.character = Instantiate((GameObject)Resources.Load<GameObject>("Karakterim"));
        
        refDic.Add("5 5", refInTile);

        GameObject grid = Grid.gridStart(sizex , sizey , offsetX , offsetY , (float)scale , material ,refDic);
    }

}

//Object Pooling//Object Pooling//Object Pooling//Object Pooling

//Object Pooling
//Object Pooling
//Object Pooling
//Object Pooling
//Object Pooling
//Object Pooling
//Object Pooling
//Object Pooling
//Object Pooling
//Object Pooling
//Object Pooling
//Object Pooling//Object Pooling
//Object Pooling//Object Pooling//Object Pooling//Object Pooling