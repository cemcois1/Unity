using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using System.Collections.Generic;



public class Turn
{
    const int STARTVALUE = 50;

    private Dictionary<string, int> turnDict;
    private int turnTime;

    public Turn() {
        this.turnDict = new Dictionary<string, int>();
        
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Chracter");
        foreach (GameObject obj in objects) {
            this.turnDict.Add(obj.name, STARTVALUE);
        }
        
        objects = GameObject.FindGameObjectsWithTag("Hostile");
        foreach (GameObject obj in objects) {
            this.turnDict.Add(obj.name, STARTVALUE);
        }

        this.turnTime = 0;
    }

    public Dictionary<string, int> runNTurn(int n = 1) {
        foreach (string name in this.turnDict.Keys) {
            this.turnDict[name] -= GameObject.Find(name).GetComponent<Character>().characterstats.getReflex();
        } 
    }
}
