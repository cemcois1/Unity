using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private Tile[,] tileMatris;
    private GameObject gameObject;
    private Vector2 offset;
    private int size;


    public Grid( int matrisX , int matrisY , float offsetX , float offsetY , float scale ,  Material material , inTile[,] tile = null)
    {
        tileMatris = new Tile[matrisX, matrisY];

        //System.Object refInTile;

        for (int X = 0; X < matrisX; X++) {
            for (int Y = 0; Y < matrisY; Y++) {
                //refInTile = null;
                //if (!tile[X, Y].Equals(new inTile()))
                //    refInTile = tile[X, Y];

                tileMatris[X, Y] = new Tile( X.ToString() + " " + Y.ToString() ,false , new inTile() , offsetX + X * scale , -( offsetY + Y * scale ) , scale ,  material);
            }
        }
        
    }

}
