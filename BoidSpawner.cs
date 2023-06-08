using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidSpawner : MonoBehaviour
{
    public GameObject[] Boids;
    //range from which the boids can spawn (should be lower than exit range, lest they be immediately eviscerated for spawning in exit zone
    public float enterRange;
    //range where boids will disappear (should be in the fog)
    public float exitRange;
    public float elevationDisplacement;
    float timeValue;
    public float frequency;
    public float playerContainerAntiFishFieldOffset;
    public bool spawning;
    Vector3 spawnPosition;

    void Start()
    {
        timeValue = Random.value * frequency;
        //spawning = true;
    }

    void Update()
    {
        if (spawning)
        {
            timeValue = Random.value * frequency;
            StartCoroutine(SpawnTimer(timeValue));
            spawning = false;
        }
    }

    public IEnumerator SpawnTimer(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        int randomValue = Random.Range(0, Boids.Length);
        GameObject Boid = Boids[randomValue];
        SpawnBoids(Boid);
        spawning = true;
    }

    private void SpawnBoids(GameObject boid)
    {
        GameObject boidGroup = Instantiate(boid, spawnPosition, Quaternion.identity);
        Boid boidScript = boid.GetComponent<Boid>();
    }
}
