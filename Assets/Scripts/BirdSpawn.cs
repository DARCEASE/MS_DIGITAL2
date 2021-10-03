using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PURPOSE: Spawn birds on the left of the screen so they can fly across 
//USAGE: Place this on an empty game object and out this script on it, you can highkey call it spawner 
public class BirdSpawn : MonoBehaviour
{
    public GameObject bird;
    public Vector2 whereToSpawn;
    public float spawnRate;
    public float nextSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            whereToSpawn = new Vector2(transform.position.x, transform.position.y* Random.Range(1,5));
            Instantiate(bird, whereToSpawn, Quaternion.identity);
        }
    }
}
