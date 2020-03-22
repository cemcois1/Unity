using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileObject { 
    Cover,
    Character,
    Null
}

public struct inTile { 
    public Cover cover;
    public Character character;
}

public class inTileTool {
    public bool isNull(inTile tile ){
        if (tile.cover == null)
            if (tile.character == null)
                return true;

        return false;
    }
}

public class Tile : MonoBehaviour
{
    private bool isReachable;
    private inTile whatsInTile;
    private Vector2 matrisCor;
    private GameObject gameObject;

    public Tile(GameObject parent, string name, bool isReachable, inTile intile = new inTile(), float offsetX = 0, float offsetY = 0, float size = 1, Material material = null)
    {
        GameObject tmpGO = GameObject.CreatePrimitive(PrimitiveType.Cube);

        this.isReachable = isReachable;
        this.whatsInTile = intile;

        this.gameObject = new GameObject(name);

        this.matrisCor = new Vector2(float.Parse(name.Split(' ')[0]), float.Parse(name.Split(' ')[1]));

        this.gameObject.transform.parent = parent.transform;

        this.gameObject.transform.position = new Vector2(offsetX, offsetY);
        this.gameObject.transform.localScale = new Vector2(size, size);

        this.gameObject.AddComponent<Tile>();

        this.gameObject.AddComponent<BoxCollider2D>();

        this.gameObject.AddComponent<MeshRenderer>();
        this.gameObject.GetComponent<MeshRenderer>().sharedMaterial = material;

        this.gameObject.AddComponent<MeshFilter>();
        this.gameObject.GetComponent<MeshFilter>().mesh = tmpGO.GetComponent<MeshFilter>().mesh;

        Destroy(tmpGO);
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

    public bool setInTile(Cover cover)
    {
        if (this.isTileFull())
            return false;

        this.whatsInTile.cover = cover;
        return true;
    }

    public bool setInTile(Character character)
    {
        if (this.isTileFull())
            return false;

        this.whatsInTile.character = character;
        return true;
    }

    public T getInTile<T>()
    {
        System.Object tmp;

        if (typeof(T) == typeof(Cover))
        {
            tmp = this.whatsInTile.cover;
            return (T)tmp;
        }

        else if (typeof(T) == typeof(Character))
        {
            tmp = this.whatsInTile.character;
            return (T)tmp;
        }

        throw new System.InvalidOperationException();
    }

    public T getInTileWithRemove<T>()
    {
        System.Object tmp;
        if (typeof(T) == typeof(Cover))
        {
            tmp = this.whatsInTile.cover;
            this.whatsInTile.cover = null;
            return (T)tmp;
        }

        else if (typeof(T) == typeof(Character))
        {
            tmp = this.whatsInTile.character;
            this.whatsInTile.character = null;
            return (T)tmp;

        }

        throw new System.InvalidOperationException();
    }

    public void highlightTile()
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
    }

    public  void OnMouseUp()
    {
        Debug.Log(this.gameObject);
    }
}