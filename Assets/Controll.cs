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

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hittedObject = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hittedObject.collider.name != null)
            if (Input.GetMouseButtonDown(0))
            {
                GameObject.Find(hittedObject.collider.name).GetComponent<Tile>().clickByMouse();
                lastObject = GameObject.Find(hittedObject.collider.name).GetComponent<Tile>().getMatrisCordinate();
            }
    }
}
