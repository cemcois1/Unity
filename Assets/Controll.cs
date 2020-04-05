using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Buttons { 
    Move,
    Melee,
    Range,
    Special,
    Special2,
}

public class Controll : MonoBehaviour
{
    Vector2 lastObject;
    
    Ray ray;
    RaycastHit2D hittedObject;

    void Start()
    {
        Turn turn = new Turn();
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hittedObject = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(hittedObject.collider.gameObject.name);
            //if (Turn.IsPlayerTurn())
            //{
            switch (hittedObject.collider.gameObject.tag)
            {
                case null:
                    Debug.Log("Null");
                    break;

                case "Tile":
                    this.gridHit(hittedObject);
                    break;

                case "Chracter":
                    Debug.Log("asdf");
                    break;

            }
                
            //}
        }
    }

    public void gridHit(RaycastHit2D paramHittedObject)
    {
        if((lastObject.x == GameObject.Find(hittedObject.collider.name).GetComponent<Tile>().getMatrisCordinate().x) && (lastObject.y == GameObject.Find(hittedObject.collider.name).GetComponent<Tile>().getMatrisCordinate().y))
            GameObject.Find("Grid").GetComponent<Grid>().unHighlightTiles(lastObject);
        else
        {
            GameObject.Find("Grid").GetComponent<Grid>().unHighlightTiles(lastObject);
            lastObject = GameObject.Find(hittedObject.collider.name).GetComponent<Tile>().getMatrisCordinate();
            GameObject.Find("Grid").GetComponent<Grid>().highlightTiles(lastObject);
        }
    }
}
