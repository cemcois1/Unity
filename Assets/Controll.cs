using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    private ButtonAction currentAction;
   
    private GraphicRaycaster graphicsRaycaster;
    private Turn turn;

    private string whosTurn;
    private bool isTurnPassed;

    void Start()
    {
        currentAction = ButtonAction.Null;
        turn = new Turn(new string[] { "Chracter", "Hostile" });

        graphicsRaycaster = GameObject.Find("Canvas").GetComponent<GraphicRaycaster>();
        whosTurn = turn.runTurn();

        lastObject = GameObject.Find("Grid").GetComponent<Grid>().whereIsChar(whosTurn);
    }

    void Update()
    {
     
        if (Input.GetMouseButtonDown(0))
        {

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hittedObject = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
         
            if (hittedObject.collider != null)
                switch (currentAction)
                {
                    case ButtonAction.Null:
                        break;

                    case ButtonAction.Move:
                        //this.moveFunc(hittedObject);
                        break;

                    case ButtonAction.Melee:
                        //this.meleeFunc(hittedObject);
                        break;

                    case ButtonAction.Range:
                        //this.rangeFunc(hittedObject);
                        break;

                    case ButtonAction.Special:
                        //this.specialFunc(hittedObject);
                        break;

                    case ButtonAction.Special2:
                        //this.special2Func(hittedObject);
                        break;

                    case ButtonAction.FinishTurn:
                        if (GameObject.Find(whosTurn).GetComponent<CharacterValue>().characterstats.getStat<int>(Stat.actionPoint) == 0)
                            this.currentAction = ButtonAction.Melee;
                        //  this.finishTurn();

                        else
                            this.currentAction = ButtonAction.Melee;
                        //this.highlightActionPoint();

                        break;
                }

            else {
                List<RaycastResult> graphRaycast = new List<RaycastResult>();
                
                PointerEventData pointerEvent = new UnityEngine.EventSystems.PointerEventData(null);
                pointerEvent.position = Input.mousePosition;

                graphicsRaycaster.Raycast(pointerEvent, graphRaycast );
                
                graphRaycast[1].gameObject.GetComponent<ButtonCode>().OnMouseUp();
                changeHighlight();
                

            }

        }
    }
    
    public void setCurrentAction(ButtonAction action) { this.currentAction = action; }

    public ButtonAction getCurrentAction () { return this.currentAction; }


    public void changeHighlight() {
        GameObject.Find("Grid").GetComponent<Grid>().unHighlightTiles(lastObject);
        GameObject.Find("Grid").GetComponent<Grid>().highlightTiles(lastObject, currentAction);
    }



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
            GameObject.Find("Grid").GetComponent<Grid>().highlightTiles(lastObject , currentAction);
        }
    
    }
}
