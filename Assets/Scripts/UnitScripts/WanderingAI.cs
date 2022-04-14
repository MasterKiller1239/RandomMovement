using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MarcoPolo
{
    public class WanderingAI : MonoBehaviour
    {
    
        private bool isWandering = false;
        private Transform target;
        private UnityEngine.AI.NavMeshAgent agent;
      

        // Use this for initialization
        void OnEnable()
        {
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
           
        }

        // Update is called once per frame
        void Update()
        {

            if (isWandering == false)
                StartCoroutine(MoveToLocation());
        }


        public IEnumerator MoveToLocation()
        {
            isWandering = true;

            Vector3 randDirection = Random.insideUnitSphere * this.GetComponent<StatsComponent>().WanderRadius;

            randDirection += transform.position;

            UnityEngine.AI.NavMeshHit navHit;

            UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, this.GetComponent<StatsComponent>().WanderRadius, -1);

            agent.SetDestination(navHit.position);

            yield return new WaitForSecondsRealtime(this.GetComponent<StatsComponent>().WanderTimer);

            isWandering = false;



        }

    }
}