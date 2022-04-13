using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public GameObject UnitPrefab;
    public List<GameObject> Units = new List<GameObject>();
    [Range(1, 10)]
    public float spawnRadius = 1;
    private bool isSpawning = true;
    private int maxNumberOfUnits = 30;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
        if(isSpawning==false && Units.Count < maxNumberOfUnits)
        StartCoroutine(Spawn());
    }
    public IEnumerator Spawn()
    {
       
        while(Units.Count< maxNumberOfUnits)
        {
            isSpawning = true;
            Vector3 randDirection = Random.insideUnitSphere * spawnRadius;

            UnityEngine.AI.NavMeshHit navHit;

            UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, spawnRadius, -1);

            GameObject newGO = (GameObject)Instantiate(UnitPrefab, navHit.position, Quaternion.identity);
            newGO.transform.parent = gameObject.transform;
            Units.Add(newGO);
            if (Units.Count == maxNumberOfUnits)
                isSpawning = false;
            yield return new WaitForSecondsRealtime(Random.Range(2f,10f));
        }
    
        
       



    }

}