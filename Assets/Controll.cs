using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonAction { 
    Move,
    Melee,
    Range,
    Special,
    Special2,
    FinishTurn,
    Null
}

public class ButtonActionTool { 
    
}

public class Controll : MonoBehaviour
{
    private Vector2 lastObject;
    private Ray ray;
    private RaycastHit2D hittedObject;
    private Turn turn;
    private ButtonAction currentAction;
    private string whosTurn;
    private bool isTurnPassed;


    void Start()
    {
        currentAction = ButtonAction.Null;
        turn = new Turn(new string[] { "Chracter", "Hostile" });
    }

    void Update()
    {
        int layerMask = LayerMask.GetMask("UI");
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hittedObject = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity , layerMask);
        if (Input.GetMouseButtonDown(0))
        {
            switch (currentAction)
            {
                case ButtonAction.Null:
                    this.gridHit(hittedObject);
                    break;

                case ButtonAction.Move:
                    this.gridHit(hittedObject);
                    break;

                case ButtonAction.Melee:
                    Debug.Log("asdf");
                    break;

                case ButtonAction.Range:
                    break;

                case ButtonAction.Special:
                    break;

                case ButtonAction.Special2:
                    break;

                case ButtonAction.FinishTurn:
                    break;

            }

            //hittedObject.collider.gameObject.tag
        }
    }

    public void setCurrentAction(ButtonAction action) { this.currentAction = action; }

    public ButtonAction getCurrentAction () { return this.currentAction; }


    public void gridHit(RaycastHit2D paramHittedObject)
    {
        if ((lastObject.x == GameObject.Find(hittedObject.collider.name).GetComponent<Tile>().getMatrisCordinate().x) && (lastObject.y == GameObject.Find(hittedObject.collider.name).GetComponent<Tile>().getMatrisCordinate().y))
        {
            GameObject.Find("Grid").GetComponent<Grid>().unHighlightTiles(lastObject);
            lastObject = new Vector2(-1 ,-1);
        }

        else
        {
            GameObject.Find("Grid").GetComponent<Grid>().unHighlightTiles(lastObject);
            lastObject = GameObject.Find(hittedObject.collider.name).GetComponent<Tile>().getMatrisCordinate();
            GameObject.Find("Grid").GetComponent<Grid>().highlightTiles(lastObject);
        }
    }
}
