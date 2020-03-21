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
        this.gameObject = new GameObject("Grid");
        tileMatris = new Tile[matrisX, matrisY];

        inTile? refInTile;
        inTileTool itt = new inTileTool();

        for (int X = 0; X < matrisX; X++) {
            for (int Y = 0; Y < matrisY; Y++) {
                refInTile = null;
                if (!itt.isNull(tile[X, Y]))
                    refInTile = tile[X, Y];

                this.tileMatris[X, Y] = new Tile( this.gameObject , X.ToString() + " " + Y.ToString() ,false , new inTile() , offsetX + X * scale , -( offsetY + Y * scale ) , scale ,  material);
            }
        }


        
    }

}
