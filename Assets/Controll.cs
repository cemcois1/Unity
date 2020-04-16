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

public enum WarnPlayer { 
    MovePoint,
    NotEnoughMoveRange,
    ToWhereIsFull,
    ToTileNotReachable
}

public class Controll : MonoBehaviour
{
    private Vector2 lastObject;
    private Ray ray;
    private RaycastHit hittedObject;

    private ButtonAction currentAction;
   
    private GraphicRaycaster graphicsRaycaster;
    private Turn turn;
    private Grid grid;

    private string whosTurn;
    private bool isTurnPassed;

    void Start()
    {
        this.grid = GameObject.Find("Grid").GetComponent<Grid>(); 

        currentAction = ButtonAction.Null;
        turn = new Turn(new string[] { "Chracter", "Hostile" });

        graphicsRaycaster = GameObject.Find("Canvas").GetComponent<GraphicRaycaster>();
        whosTurn = turn.runTurn();

        lastObject = this.grid.whereIsChar(whosTurn);
    }

    void Update()
    {
     
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(transform.position,ray.direction, out hittedObject);            

            if (hittedObject.collider != null)
                switch (currentAction)
                {
                    case ButtonAction.Null:
                        break;

                    case ButtonAction.Move:
                        if (this.grid.getTile(lastObject).GetComponent<Tile>().getInTile<Character>().GetComponent<CharacterValue>().movePoint < 0)
                        {
                            this.warnPlayer(WarnPlayer.MovePoint);
                            break;
                        }

                        this.grid.tileHighlighter(lastObject, currentAction);

                        if (this.moveFunc(this.grid.getTile(hittedObject.collider.name).GetComponent<Tile>().getMatrisCordinate()))
                        {
                            
                            this.lastObject = this.grid.getTile(hittedObject.collider.name).GetComponent<Tile>().getMatrisCordinate();
                        }
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
                this.grid.tileHighlighter(lastObject , currentAction);
                

            }

        }
    }
    
    public void setCurrentAction(ButtonAction action) { this.currentAction = action; }


    public ButtonAction getCurrentAction () { return this.currentAction; }


    private bool moveFunc(Vector2 vec) {
        if (this.grid.getTile(vec).GetComponent<Tile>().isTileFull()) {
            this.warnPlayer(WarnPlayer.ToWhereIsFull);
            return false;
                }

        if (this.grid.getTile(vec).GetComponent<Tile>().isItReachable() == true)
        {
            this.warnPlayer(WarnPlayer.ToTileNotReachable);
            return false;
        }

        if (Mathf.Pow(this.grid.getTile(lastObject).GetComponent<Tile>().getInTile<Character>().GetComponent<CharacterValue>().characterstats.getStat<int>(Stat.moveRange),0.5f) < Grid.calDistanceBetTile(lastObject, vec))
        {
            this.warnPlayer(WarnPlayer.NotEnoughMoveRange);
            return false;
        }

        this.grid.moveCharacter(lastObject, vec);
        this.grid.getTile(vec).GetComponent<Tile>().getInTile<Character>().GetComponent<Transform>().position = this.grid.getTile(vec).GetComponent<Transform>().position;
        
        return true;
        

    }

    private void warnPlayer(WarnPlayer reason) { }
}
