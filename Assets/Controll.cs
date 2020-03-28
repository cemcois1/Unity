using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{
    Vector2 lastObject;

    Ray ray;
    RaycastHit2D hittedObject;

    void Start()
    {

    }

    void Update()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hittedObject = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (Input.GetMouseButtonDown(0))
        {
            if (hittedObject.collider.gameObject.tag == "Tile")
            {
                this.gridHit(hittedObject);

            }
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
