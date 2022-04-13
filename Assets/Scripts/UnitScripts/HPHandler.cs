using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarcoPolo
{
    public class HPHandler : MonoBehaviour
    {
        private int maxHP = 3;
        public int currentHP = 3;

        public int MaxHP { get => maxHP; set => maxHP = value; }
        

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (currentHP <= 0)
            {
                if (GetComponentInParent<UnitSpawner>().Units.Remove(this.gameObject))
                    Destroy(this.gameObject);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == 6)
                currentHP--;

        
        }
    }
}
