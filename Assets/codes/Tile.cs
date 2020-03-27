﻿using System.Collections;
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
    public Cover cover;
    public Character character;
}

public class inTileTool
{
    public bool isNull(inTile tile)
    {
        if (tile.cover == null)
            if (tile.character == null)
                return true;

        return false;
    }
}


public class Tile : MonoBehaviour
{
    private bool isHighlishted = false;
    private bool isReachable;
    private Color defaultColor;
    private inTile whatsInTile;
    private Vector2 matrisCor;

    private Tile() { }

    public static void TileAdder(GameObject tile, GameObject parent, string name, bool isReachable, inTile intile = new inTile(), float offsetX = 0, float offsetY = 0, float size = 1, Material material = null)
    {
        GameObject tmpGO = GameObject.CreatePrimitive(PrimitiveType.Cube);

        tile.AddComponent<Tile>();
        tile.GetComponent<Tile>().isReachable = isReachable;
        tile.GetComponent<Tile>().whatsInTile = intile;

        tile.GetComponent<Tile>().matrisCor = new Vector2(float.Parse(name.Split(' ')[0]), float.Parse(name.Split(' ')[1]));

        tile.transform.parent = parent.transform;

        tile.transform.position = new Vector2(offsetX, offsetY);
        tile.transform.localScale = new Vector2(size, size);

        tile.AddComponent<BoxCollider2D>();

        tile.AddComponent<MeshRenderer>().sharedMaterial = material;

        tile.AddComponent<MeshFilter>().mesh = tmpGO.GetComponent<MeshFilter>().mesh;

        tile.GetComponent<Tile>().defaultColor = tile.GetComponent<MeshRenderer>().material.color;
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
        isHighlishted = !isHighlishted;
        GameObject.Find(this.gameObject.name).GetComponent<MeshRenderer>().material.color = Color.white;
    }

    public void unHighlightTile()
    {
        isHighlishted = !isHighlishted;
        this.GetComponent<MeshRenderer>().material.color = defaultColor;
    }

    public void clickByMouse()
    {
        Debug.Log(this.GetType());

        switch (isHighlishted)
        {
            case false:
                this.highlightTile();
                break;

            case true:
                this.unHighlightTile();
                break;
        }

    }
}
