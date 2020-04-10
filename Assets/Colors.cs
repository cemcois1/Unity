using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Colors", order = 0)]
public class Colors : ScriptableObject
{ 
    [SerializeField] private Color nullColor;
    [SerializeField] private Color moveColor;
    [SerializeField] private Color meleeColor;
    [SerializeField] private Color rangeColor;
    [SerializeField] private Color specialColor;
    [SerializeField] private Color special2Color;
    [SerializeField] private Color finishTurnColor;

    public Color getColor(ButtonAction action) {
        switch (action) {
            case (ButtonAction.Null):
                return this.nullColor;

            case (ButtonAction.Move):
                return this.moveColor;

            case (ButtonAction.Melee):
                return this.meleeColor;

            case (ButtonAction.Range):
                return this.rangeColor;

            case (ButtonAction.Special):
                return this.specialColor;

            case (ButtonAction.Special2):
                return this.special2Color;

            case (ButtonAction.FinishTurn):
                return this.finishTurnColor;

            default:
                return Color.white;
        }
    }

    public void setColor(ButtonAction action, Color color) {
        switch (action) {
            case (ButtonAction.Null):
                this.nullColor = color;
                break;

            case (ButtonAction.Move):
                this.moveColor = color;
                break;

            case (ButtonAction.Melee):
                this.meleeColor = color;
                break;

            case (ButtonAction.Range):
                this.rangeColor = color;
                break;

            case (ButtonAction.Special):
                this.specialColor = color;
                break;

            case (ButtonAction.Special2):
                this.special2Color = color;
                break;

            case (ButtonAction.FinishTurn):
                this.finishTurnColor = color;
                break;

        }

    }
}
