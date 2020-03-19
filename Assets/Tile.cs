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

[CreateAssetMenu(fileName = "Create", menuName = "deneme2")]
public class Tile : ScriptableObject
{
    private bool isReachable;
    private inTile whatsInTile;


    public Tile(bool isReachable, inTile intile = new inTile()){
        this.isReachable = isReachable;
        this.whatsInTile = intile;
    }

    public bool isTileFull() {
        if (whatsInTile.character != null)
            return true;

        if (whatsInTile.cover != null)
            return true;

        return false;
    }

    public TileObject whatInTile() {
        if (whatsInTile.character != null)
            return TileObject.Character;

        if (whatsInTile.cover != null)
            return TileObject.Cover;

        return TileObject.Null; 
    }

    public bool isItReachable() {
        return this.isReachable;
    }

    public bool setInTile(Cover cover) {
        if (this.isTileFull())
            return false;

        this.whatsInTile.cover = cover;
        return true;
    }

    public bool setInTile(Character character) {
        if (this.isTileFull())
            return false;

        this.whatsInTile.character = character;
        return true;
    }

    public T getInTile<T>() {
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

    public T getInTileWithRemove<T>() {
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

}

public class Grid : ScriptableObject {
    Tile[,] tiles;

}