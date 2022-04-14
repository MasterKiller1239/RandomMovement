using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarcoPolo
{
    public class HPHandler : MonoBehaviour
    {
        
        

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (this.GetComponent<StatsComponent>().CurrentHP <= 0)
            {
                if (GetComponentInParent<UnitSpawner>().Units.Remove(this.gameObject))
                    Destroy(this.gameObject);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
           
            if (collision.gameObject.CompareTag("Enemy"))
                this.GetComponent<StatsComponent>().CurrentHP--;
           

        
        }
    }
}
