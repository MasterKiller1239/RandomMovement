using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public GameObject UnitPrefab;
    List<GameObject> enemies = new List<GameObject>();
    [Range(1, 10)]
    public float spawnRadius = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
       
        while(enemies.Count<30)
        {
            Vector3 randDirection = Random.insideUnitSphere * spawnRadius;

            UnityEngine.AI.NavMeshHit navHit;

            UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, spawnRadius, -1);

            GameObject newGO = (GameObject)Instantiate(UnitPrefab, navHit.position, Quaternion.identity);
            enemies.Add(newGO);

            yield return new WaitForSecondsRealtime(Random.Range(2,10));
        }
    

       



    }

}
