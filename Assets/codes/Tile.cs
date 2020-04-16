using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileObject
{
    Cover,
    Character,
    Null
}

public struct inTile
{
    public GameObject cover;
    public GameObject character;
}

public class inTileTool
{
    public static bool isNull(inTile tile)
    {
        if (tile.cover == null)
            if (tile.character == null)
                return true;

        return false;
    }

    public static TileObject whatInIt(inTile referance) {
        if (referance.character != null)
            return TileObject.Character;

        else if (referance.cover != null)
            return TileObject.Cover;

        else
            return TileObject.Null;
    }

}


public class Tile : MonoBehaviour
{
    private bool isHighlishted = false;
    private bool isReachable;

    public Color defaultColor;
    private inTile whatsInTile;
    private Vector2 matrisCor;

    private Tile() { }

    public static GameObject TileAdder(GameObject tile, GameObject parent, bool isReachable, inTile intile = new inTile(), float offsetX = 0, float offsetY = 0, float size = 1, Material material = null)
    {
        GameObject tmpGO = GameObject.CreatePrimitive(PrimitiveType.Cube);

        tile.tag = "Tile";

        tile.AddComponent<Tile>();
        tile.GetComponent<Tile>().isReachable = isReachable;
        tile.GetComponent<Tile>().whatsInTile = intile;

        tile.GetComponent<Tile>().matrisCor = new Vector2(float.Parse(tile.name.Split(' ')[0]), float.Parse(tile.name.Split(' ')[1]));

        tile.transform.parent = parent.transform;

        tile.transform.position = new Vector2(offsetX, offsetY);
        tile.transform.localScale = new Vector2(size, size);

        tile.AddComponent<BoxCollider>();

        tile.AddComponent<MeshRenderer>().sharedMaterial = material;

        tile.AddComponent<MeshFilter>().mesh = tmpGO.GetComponent<MeshFilter>().mesh;

        tile.GetComponent<Tile>().defaultColor = tile.GetComponent<MeshRenderer>().material.color;
        Destroy(tmpGO);

        return tile;
    }


    public Vector2 getMatrisCordinate()
    {
        return this.matrisCor;
    }

    public bool isTileFull()
    {
        if (whatsInTile.character != null)
            return true;

        if (whatsInTile.cover != null)
            return true;

        return false;
    }

    public TileObject whatInTile()
    {
        if (whatsInTile.character != null)
            return TileObject.Character;

        if (whatsInTile.cover != null)
            return TileObject.Cover;

        return TileObject.Null;
    }

    public bool isItReachable()
    {
        return this.isReachable;
    }



    public bool setInTile<Ty>(GameObject obj) {
        if (!this.isTileFull())
            if (typeof(Ty) == typeof(Cover))
                this.whatsInTile.cover = obj;


            else if (typeof(Ty) == typeof(Character))
            {
                this.whatsInTile.character = obj;
            }

            else
                throw new System.InvalidOperationException();
        else
            return false;

        return true;

    }

    public GameObject getInTile<T>()
    {
        if (typeof(T) == typeof(Cover))
        {
            return this.whatsInTile.cover;
        }

        else if (typeof(T) == typeof(Character))
        {
            return this.whatsInTile.character;
        }

        throw new System.InvalidOperationException();
    }


    public GameObject getInTileWithRemove<T>()
    {
        GameObject tmp;
        if (typeof(T) == typeof(Cover))
        {
            tmp = this.whatsInTile.cover;
            this.whatsInTile.cover = null;
            return tmp;
        }

        else if (typeof(T) == typeof(Character))
        {
            tmp = this.whatsInTile.character;
            this.whatsInTile.character = null;
            return tmp;

        }

        throw new System.InvalidOperationException();
    }

    public void highlightTile(Color color)
    {
        isHighlishted = !isHighlishted;
        GameObject.Find(this.gameObject.name).GetComponent<MeshRenderer>().material.color = color;
    }

    public void unHighlightTile()
    {
        isHighlishted = !isHighlishted;
        GameObject.Find(this.gameObject.name).GetComponent<MeshRenderer>().material.color = GameObject.Find(this.gameObject.name).GetComponent<Tile>().defaultColor;
    }

    public void clickByMouse()
    {
        switch (GameObject.Find(this.gameObject.name).GetComponent<Tile>().isHighlishted)
        {
            case false:
                GameObject.Find(this.gameObject.name).GetComponent<Tile>().highlightTile(Color.white);
                break;

            case true:
                GameObject.Find(this.gameObject.name).GetComponent<Tile>().unHighlightTile();
                break;
        }

    }
}
