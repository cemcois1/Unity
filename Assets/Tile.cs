using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Cover getInTile(  )

}
