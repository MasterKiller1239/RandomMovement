using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;
    private bool isWandering = false;
    private Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private float timer;

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
 
        if(isWandering==false)
        StartCoroutine(MoveToLocation());
    }

  
    public IEnumerator  MoveToLocation()
    {
        isWandering = true;

        Vector3 randDirection = Random.insideUnitSphere * wanderRadius;

        randDirection += transform.position;

        UnityEngine.AI.NavMeshHit navHit;

        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, wanderRadius, -1);

        agent.SetDestination(navHit.position);

        yield return new WaitForSecondsRealtime(wanderTimer);

        isWandering = false;



    }

}
