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
    public Character chracter;
}

public class Tile : ScriptableObject
{
    private bool isReachable;
    private inTile whatsInTile;

    public Tile(bool isReachable, inTile intile = new inTile()){
        this.isReachable = isReachable;
        this.whatsInTile = intile;
    }

    public bool isTileFull() {
        if (whatsInTile.chracter != null)
            return true;

        if (whatsInTile.cover != null)
            return true;

        return false;
    }

    public TileObject whatInTile() {
        if (whatsInTile.chracter != null)
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

        this.whatsInTile.chracter = character;
        return true;
    }

    public T getInTile<T>() {
        if (typeof(T) == typeof(Cover))
            return this.whatsInTile.cover;

        else if (typeof(T) == typeof(Chracter))
            return this.whatsInTile.chracter;

        throw new System.InvalidOperationException();
    }

    public T getInTileWithRemove<T>() {
        if (typeof(T) == typeof(Cover))
            Cover retCov = Cover.CopyTothis.whatsInTile.cover;
            return this.whatsInTile.cover;

        else if (typeof(T) == typeof(Chracter))
            return this.whatsInTile.chracter;

        throw new System.InvalidOperationException();
    }

}
