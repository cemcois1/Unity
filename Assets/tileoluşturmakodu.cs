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
        Grid grid = new Grid(sizex , sizey , offsetX , offsetY , (float)scale , material );
    }

}
