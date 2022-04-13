using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHanlder : MonoBehaviour
{
    GameObject Unit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = CastRay();

            if(hit.collider.GetComponent<StatsComponent>()!=null)
            {
                Unit = hit.collider.gameObject;
            }
        }
    }
    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x,
           Input.mousePosition.y,
           Camera.main.nearClipPlane);
        Vector3 worldMopusePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMopusePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMopusePosNear, worldMopusePosFar - worldMopusePosNear, out hit);

        return hit;
    }
}
