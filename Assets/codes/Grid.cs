using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

public class Grid : MonoBehaviour
{
    public Tile[,] tileMatris;
    private GameObject gameObject;
    private Vector2 offset;
    private int size;

    public Grid( int matrisX , int matrisY , float offsetX , float offsetY , float scale ,  Material material , inTile[,] tile = null)
    {
        this.gameObject = new GameObject("Grid");
        tileMatris = new Tile[matrisX, matrisY];

        bool isNull = false;
        if (tile == null)
            isNull = true;

        inTile? refInTile;
        inTileTool itt = new inTileTool();

        for (int X = 0; X < matrisX; X++) {
            for (int Y = 0; Y < matrisY; Y++) {
                refInTile = null;
                if (!isNull)
                    if (!itt.isNull(tile[X, Y]))
                        refInTile = tile[X, Y];

                this.tileMatris[X, Y] = new Tile( this.gameObject , X.ToString() + " " + Y.ToString() ,false , new inTile() , offsetX + X * scale , -( offsetY + Y * scale ) , scale ,  material);
            }
        }

    }


    private float calDistanceBetTile(Tile tile1 , Tile tile2) {
        return (float)Math.Pow(Math.Sqrt(tile1.getMatrisCordinate().x - tile2.getMatrisCordinate().x) + Math.Sqrt(tile1.getMatrisCordinate().y - tile2.getMatrisCordinate().y), 0.5f);
    }

    public void highlightTiles(GameObject gameObject) {
        
    }

    private void OnMouseUp()
    {
        Debug.Log("asdfg");
    }
}
