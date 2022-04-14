using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MarcoPolo
{
    public class RaycastHandler : MonoBehaviour
{
        private GameObject Unit;
        public  UIController UICon;
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
                if (Unit != null)
                {
                    Unit.GetComponent<UnitRandererHandler>().SelectUnit(false);
                    UICon.HideInfoAboutUnit();
                    Unit = null;
                }
                
              
                if (hit.collider != null)
                    if (hit.collider.CompareTag("Enemy"))
            {
                
                    Unit = hit.collider.gameObject;
                    Unit.GetComponent<UnitRandererHandler>().SelectUnit(true);
                    UICon.ShowInfoAboutUnit(Unit);

                }
        }
    }
        //Cast a ray and returns first object hit
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
}