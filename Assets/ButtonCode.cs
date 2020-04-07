using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnMouseUp()
    {
        int tmp = 0;
        ButtonAction retValue = ButtonAction.Null;
        
        tmp = this.gameObject.name.Contains("Move") ? 1 : tmp;
        tmp = this.gameObject.name.Contains("Melee") ? 2 : tmp;
        tmp = this.gameObject.name.Contains("Range") ? 3 : tmp;
        tmp = this.gameObject.name.Contains("Special") ? 4 : tmp;
        tmp = this.gameObject.name.Contains("Special2") ? 5 : tmp;
        tmp = this.gameObject.name.Contains("FinishTurn") ? 6 : tmp;
        tmp = this.gameObject.name.Contains("Null") ? 0: tmp;

        switch (tmp) {
            case 0:
                Debug.Log("Null Returned From Buttons");
                retValue = ButtonAction.Null;
                break;

            case 1:
                retValue = ButtonAction.Move;
                break;

            case 2:
                retValue = ButtonAction.Melee;
                break;

            case 3:
                retValue = ButtonAction.Range;
                break;

            case 4:
                retValue = ButtonAction.Special;
                break;

            case 5:
                retValue = ButtonAction.Special2;
                break;

            case 6:
                retValue = ButtonAction.FinishTurn;
                break;
        }

        GameObject.Find("Main Camera").GetComponent<Controll>().setCurrentAction( retValue );
    }
}
