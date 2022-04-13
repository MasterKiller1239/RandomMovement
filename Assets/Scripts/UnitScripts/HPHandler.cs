using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPHandler : MonoBehaviour
{
   private int maxHP = 3;
    public int currentHP = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer==6)
            currentHP--;

        if (currentHP<=0)
        {
            if(GetComponentInParent<UnitSpawner>().Units.Remove(collision.gameObject))
            Destroy(this.gameObject);
        }
    }
}
