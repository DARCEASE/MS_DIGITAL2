using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public GameObject target;
    public Vector2 spawnTarget;
    // Start is called before the first frame update
    void Start()
    {
       spawnTarget = new Vector2(transform.position.x * Random.Range(2, 20), transform.position.y);
       Instantiate(target, spawnTarget, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LilGuy")
        {
            Debug.Log("lil guy landed!!");
            //score goes up by 1 
            //level resets and spawns target in new position 
        }
    }
}
