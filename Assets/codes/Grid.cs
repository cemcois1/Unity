using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

public class Grid : MonoBehaviour
{
    private Vector2 matrisSize;
    private Dictionary<string,GameObject> tileMatris;
    private Vector2 offset;
    private int size;

    private Grid() { }

    public static GameObject gridStart(int matrisX, int matrisY, float offsetX, float offsetY, float scale, Material material, Dictionary<string,inTile> tile = null)
    {
        GameObject tmp = new GameObject("Grid");
        tmp.AddComponent<Grid>();
        tmp.GetComponent<Grid>().matrisSize = new Vector2(matrisX, matrisY);

        tmp.GetComponent<Grid>().tileMatris = new Dictionary<string, GameObject>();

        bool isNull = (tile == null? true: false);

        inTile? refInTile;
        inTileTool itt = new inTileTool();

        for (int X = 0; X < matrisX; X++) {
            for (int Y = 0; Y < matrisY; Y++) {
                refInTile = null;
            
                if (!isNull)
                    if (tile.ContainsKey(X.ToString() + " " + Y.ToString()))
                    {
                        refInTile = tile[X.ToString() + " " + Y.ToString()];
                        refInTile.Value.character.GetComponent<Transform>().position = new Vector3(offsetX + X * scale, -(offsetY + Y * scale), -0.1f);
                        refInTile.Value.character.GetComponent<Transform>().localScale = new Vector2(scale, scale);
                    }
                
                tmp.GetComponent<Grid>().tileMatris.Add(X.ToString() + " " + Y.ToString(), Tile.TileAdder(new GameObject(X.ToString() + " " + Y.ToString()), tmp, false, new inTile(), offsetX + X * scale, -(offsetY + Y * scale), scale, material));
            
            }
        }

        return tmp;
    }

    public GameObject getTile(int x, int y ) {
        if (matrisSize.x < x || matrisSize.y < y)
            return null;
        return tileMatris[x.ToString() + " " + y.ToString()];
    }

    private static float calDistanceBetTile(Vector2 vector1, Vector2 vector2) { 
        return (float)Math.Pow(Math.Sqrt(vector2.x < vector1.x ? vector1.x - vector2.x : vector2.x - vector1.x) + Math.Sqrt(vector2.y < vector1.y ? vector1.y - vector2.y : vector2.y - vector1.y), 0.5f);
    }

    public void highlightTiles(Vector2 cordinate) {
        Grid tmp = GameObject.Find("Grid").GetComponent<Grid>();
        int llll = 3;
        for (int x = (int)cordinate.x - llll < 0 ? 0 : (int)cordinate.x - llll; x <= (int)cordinate.x + llll; x++) {
            for (int y = (int)cordinate.y - llll < 0 ? 0 : (int)cordinate.y - llll; y <= (int)cordinate.y + llll; y++)
            {
                if (Grid.calDistanceBetTile(new Vector2(x, y), cordinate) < Math.Pow(llll, 0.5f)) {
                    tmp.getTile(x,y).GetComponent<Tile>().highlightTile();
                }
            }
        }

    }

    public void unHighlightTiles(Vector2 cordinate) {
        Grid tmp = GameObject.Find("Grid").GetComponent<Grid>();
        int llll = 3;
        for (int x = (int)cordinate.x - llll < 0 ? 0 : (int)cordinate.x - llll; x <= (int)cordinate.x + llll; x++)
        {
            for (int y = (int)cordinate.y - llll < 0 ? 0 : (int)cordinate.y - llll; y <= (int)cordinate.y + llll; y++)
            {
                 tmp.getTile(x,y).GetComponent<Tile>().unHighlightTile();
            
            }
        }
    }
}
