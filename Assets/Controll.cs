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
        if (hittedObject.collider.name != null)
            if (Input.GetMouseButtonDown(0))
            {
                lastObject = GameObject.Find(hittedObject.collider.name).GetComponent<Tile>().getMatrisCordinate();
                GameObject.Find("Grid").GetComponent<Grid>().highlightTiles(lastObject);
            }
    }
}
