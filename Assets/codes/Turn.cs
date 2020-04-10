using System.Collections.Generic;

using UnityEngine;



public class Turn
{
    int STARTVALUE = 50;

    private Dictionary<string, int> turnDict;
    private int turnTime;

    public Turn(string[] tags ) {
        this.turnDict = new Dictionary<string, int>();

        foreach (string name in tags) 
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag(name))
                this.turnDict.Add(obj.name, STARTVALUE++);

        this.turnTime = 0;
    }

    private Dictionary<string, int> calcNTurn(int n = 1) {
        for (int i = 0; i < n; i++)
        {
            foreach (string name in this.turnDict.Keys)
            {
                int asd = GameObject.Find(name).GetComponent<Character>().characterstats.getStat<int>(Stat.reflex);
                this.turnDict[name] -= GameObject.Find(name).GetComponent<Character>().characterstats.getStat<int>(Stat.reflex);
            }

            this.turnTime++;
        }
        return this.turnDict;
    }
    
    private string whosTurn(Dictionary<string, int> input) {
        List<string> belowZero = new List<string>();

        foreach (string name in this.turnDict.Keys) {
            if (this.turnDict[name] < 0)
                belowZero.Add(name);
        }

        if (belowZero.Count == 0)
            return null;

        if (belowZero.Count == 1)
            return belowZero.ToArray()[0];

        string chosenOne = belowZero.ToArray()[new System.Random().Next(0, belowZero.Count)];
        belowZero.Remove(chosenOne);

        foreach (string name in belowZero)
            this.turnDict[name] = 0;

        return chosenOne;
    }

    public string runTurn( ) {
        string retName = this.whosTurn( this.turnDict );

        if (retName == null){
            this.calcNTurn(1);
            return this.runTurn();   
        }

        return retName;

    }
    
}
