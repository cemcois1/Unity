using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

public class Grid : MonoBehaviour
{
    private Vector2 matrisSize;
    private GameObject gameObject;
    private Vector2 offset;
    private int size;

    public Grid(int matrisX, int matrisY, float offsetX, float offsetY, float scale, Material material, inTile[,] tile = null)
    {
        this.gameObject = new GameObject("Grid");
        this.gameObject.AddComponent<Grid>();
        GameObject.Find("Grid").GetComponent<Grid>().matrisSize = new Vector2(matrisX, matrisY);

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

                Tile.TileAdder(new GameObject(X.ToString() + " " + Y.ToString()), this.gameObject, X.ToString() + " " + Y.ToString(), false, new inTile(), offsetX + X * scale, -(offsetY + Y * scale), scale, material);
            }
        }

    }


    private static float calDistanceBetTile(Vector2 vector1, Vector2 vector2) { 
        return (float)Math.Pow(Math.Sqrt(vector2.x < vector1.x ? vector1.x - vector2.x : vector2.x - vector1.x) + Math.Sqrt(vector2.y < vector1.y ? vector1.y - vector2.y : vector2.y - vector1.y), 0.5f);
    }

    public void highlightTiles(Vector2 cordinate) {
        int llll = 3;
        for (int x = (int)cordinate.x - llll < 0 ? 0 : (int)cordinate.x - llll; x <= (int)cordinate.x + llll; x++) {
            for (int y = (int)cordinate.y - llll < 0 ? 0 : (int)cordinate.y - llll; y <= (int)cordinate.y + llll; y++)
            {
                if (Grid.calDistanceBetTile(new Vector2(x, y), cordinate) < Math.Pow(llll, 0.5f)) {
                    GameObject.Find(x.ToString() + " " + y.ToString()).GetComponent<Tile>().highlightTile();
                }
            }
        }

    }

    public void unHighlightTiles(Vector2 cordinate) {
        int llll = 3;
        for (int x = (int)cordinate.x - llll < 0 ? 0 : (int)cordinate.x - llll; x <= (int)cordinate.x + llll; x++)
        {
            for (int y = (int)cordinate.y - llll < 0 ? 0 : (int)cordinate.y - llll; y <= (int)cordinate.y + llll; y++)
            {
                 GameObject.Find(x.ToString() + " " + y.ToString()).GetComponent<Tile>().unHighlightTile();
            
            }
        }
    }
}
