using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

public class Grid : MonoBehaviour
{
    private Vector2 matrisSize;
    private Dictionary<string, Vector2> charPosition;
    private Dictionary<string, GameObject> tileMatris;
    private Vector2 offset;
    private int size;

    private Grid() { }

    public static GameObject gridStart(int matrisX, int matrisY, float offsetX, float offsetY, float scale, Material material, Dictionary<string, inTile> tile = null)
    {
        GameObject tmp = new GameObject("Grid");
        tmp.AddComponent<Grid>();

        tmp.GetComponent<Grid>().matrisSize = new Vector2(matrisX, matrisY);
        tmp.GetComponent<Grid>().tileMatris = new Dictionary<string, GameObject>();
        tmp.GetComponent<Grid>().charPosition = new Dictionary<string, Vector2>();

        bool isNull = (tile == null ? true : false);

        inTile refInTile;
        inTileTool itt = new inTileTool();

        for (int X = 0; X < matrisX; X++)
        {
            for (int Y = 0; Y < matrisY; Y++)
            {
                refInTile = new inTile();

                if (!isNull)
                    if (tile.ContainsKey(X.ToString() + " " + Y.ToString()))
                    {
                        refInTile = tile[X.ToString() + " " + Y.ToString()];

                        if (inTileTool.whatInIt(refInTile) == TileObject.Character)
                            tmp.GetComponent<Grid>().charPosition.Add(refInTile.character.name, new Vector2(X, Y));
                        refInTile.character.GetComponent<Transform>().position = new Vector3(offsetX + X * scale, -(offsetY + Y * scale), -0.1f);
                        refInTile.character.GetComponent<Transform>().localScale = new Vector2(scale, scale);
                    }

                tmp.GetComponent<Grid>().tileMatris.Add(X.ToString() + " " + Y.ToString(), Tile.TileAdder(new GameObject(X.ToString() + " " + Y.ToString()), tmp, false, new inTile(), offsetX + X * scale, -(offsetY + Y * scale), scale, material));

            }
        }

        return tmp;
    }

    public GameObject getTile(int x, int y)
    {
        if (matrisSize.x < x || matrisSize.y < y)
        {
            Debug.Log("Hata Alındı");
            return null;
        }
        else
        {
            return tileMatris[x.ToString() + " " + y.ToString()];
            Debug.Log("Hata Alındı");

        }

    }

    private static float calDistanceBetTile(Vector2 vector1, Vector2 vector2)
    {
        return (float)Math.Pow(Math.Sqrt(vector2.x < vector1.x ? vector1.x - vector2.x : vector2.x - vector1.x) + Math.Sqrt(vector2.y < vector1.y ? vector1.y - vector2.y : vector2.y - vector1.y), 0.5f);
    }

    public Vector2 whereIsChar(string name)
    {
        List<string> tmp = new List<string>(this.charPosition.Keys);
        foreach (string feName in tmp)
            if (feName == name)
                return this.charPosition[name];

        return new Vector2(-1, -1);
    }


    public void highlightTiles(Vector2 cordinate, ButtonAction action)
    {
        Grid tmp = GameObject.Find("Grid").GetComponent<Grid>();
        Debug.Log(tmp.name);

        int highlightArea;
        Color highlightColor;

        switch (action)
        {
            case (ButtonAction.Move):
                Debug.Log("cordinate.x= "+ cordinate.x+ " cordinate.y="+ cordinate.y);
                highlightArea = tmp.getTile((int)cordinate.x, (int)cordinate.y).GetComponent<Tile>().getInTile<Character>().characterstats.getStat<int>(Stat.moveRange);
                Debug.Log((int)highlightArea);
                highlightColor = tmp.getTile((int)cordinate.x, (int)cordinate.y).GetComponent<CharacterValue>().charColors.getColor(ButtonAction.Move);
                break;

            case (ButtonAction.Range):
                highlightArea = tmp.getTile((int)cordinate.x, (int)cordinate.y).GetComponent<Tile>().getInTile<Character>().characterstats.getStat<int>(Stat.attackRange);
                highlightColor = tmp.getTile((int)cordinate.x, (int)cordinate.y).GetComponent<CharacterValue>().charColors.getColor(ButtonAction.Range);
                break;

            case (ButtonAction.Melee):
                highlightArea = 1;
                highlightColor = tmp.getTile((int)cordinate.x, (int)cordinate.y).GetComponent<CharacterValue>().charColors.getColor(ButtonAction.Melee);
                break;

            case (ButtonAction.Special):
                highlightArea = 0;
                highlightColor = tmp.getTile((int)cordinate.x, (int)cordinate.y).GetComponent<CharacterValue>().charColors.getColor(ButtonAction.Special);
                break;

            case (ButtonAction.Special2):
                highlightArea = 0;
                highlightColor = tmp.getTile((int)cordinate.x, (int)cordinate.y).GetComponent<CharacterValue>().charColors.getColor(ButtonAction.Special2);
                break;

            case (ButtonAction.FinishTurn):
                highlightArea = 0;
                highlightColor = tmp.getTile((int)cordinate.x, (int)cordinate.y).GetComponent<CharacterValue>().charColors.getColor(ButtonAction.FinishTurn);
                break;

            case (ButtonAction.Null):
                highlightArea = 0;
                highlightColor = tmp.getTile((int)cordinate.x, (int)cordinate.y).GetComponent<CharacterValue>().charColors.getColor(ButtonAction.Null);
                break;

            default:
                highlightArea = 0;
                highlightColor = Color.white;
                break;
        }



        for (int x = (int)cordinate.x - highlightArea < 0 ? 0 : (int)cordinate.x - highlightArea; x <= (int)cordinate.x + highlightArea; x++)
        {
            for (int y = (int)cordinate.y - highlightArea < 0 ? 0 : (int)cordinate.y - highlightArea; y <= (int)cordinate.y + highlightArea; y++)
            {
                if (cordinate.x == x && cordinate.y == y)
                    continue;

                if (Grid.calDistanceBetTile(new Vector2(x, y), cordinate) < Math.Pow(highlightArea, 0.5f))
                {
                    tmp.getTile(x, y).GetComponent<Tile>().highlightTile(highlightColor);
                }
            }
        }

    }

    public void unHighlightTiles(Vector2 cordinate)
    {
        Grid tmp = GameObject.Find("Grid").GetComponent<Grid>();
        int llll = 3;
        for (int x = (int)cordinate.x - llll < 0 ? 0 : (int)cordinate.x - llll; x <= (int)cordinate.x + llll; x++)
        {
            for (int y = (int)cordinate.y - llll < 0 ? 0 : (int)cordinate.y - llll; y <= (int)cordinate.y + llll; y++)
            {
                tmp.getTile(x, y).GetComponent<Tile>().unHighlightTile();

            }
        }
    }
}
