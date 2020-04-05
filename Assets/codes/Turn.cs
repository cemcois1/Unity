using System.Collections.Generic;

using UnityEngine;



public class Turn
{
    int STARTVALUE = 50;

    private Dictionary<string, int> turnDict;
    private int turnTime;

    public Turn() {
        this.turnDict = new Dictionary<string, int>();
        
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Chracter");
        foreach (GameObject obj in objects) {
            this.turnDict.Add(obj.name, STARTVALUE++);
        }
        
        objects = GameObject.FindGameObjectsWithTag("Hostile");
        foreach (GameObject obj in objects) {
            this.turnDict.Add(obj.name, STARTVALUE++);
        }

        this.turnTime = 0;
    }

    public Dictionary<string, int> calcNTurn(int n = 1) {
        for (int i = 0; i < n; i++)
        {
            foreach (string name in this.turnDict.Keys)
            {
                this.turnDict[name] -= GameObject.Find(name).GetComponent<Character>().characterstats.getReflex();
            }

            this.turnTime++;
        }
        return this.turnDict;
    }
    /*
    private string whosTurn(Dictionary<string, int> input) {
        List<string> belowZero = new List<string>();

        foreach (string name in this.turnDict.Keys) {
            if (this.turnDict[name] < 0)
                belowZero.Add(name);
        }

        if (belowZero.Count == 1)
            return belowZero.ToArray()[0];
        for(int i = 1; i< bew)
        return belowZero.ToArray()[new System.Random().Next(0 , belowZero.Count)];
        
    }

    public string runNTurn(int n = 1) {
        for (int i = 0; i < n; i++) { 
            
        }
    
    }
    */
}
