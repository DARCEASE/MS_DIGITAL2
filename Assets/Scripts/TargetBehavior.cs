using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
//PURPOSE: To spawn a target ina  random pos along the x axis 
//USAGE: Place on empty obj that is going to be your spawner for targets (target prefab needed)
public class TargetBehavior : MonoBehaviour
{
    public GameObject target;
    public Vector2 spawnTarget;
    // Start is called before the first frame update
    void Start()
    {
       spawnTarget = new Vector2(transform.position.x + Random.Range(8, 16), transform.position.y); // spawn at random x pos 
       Instantiate(target, spawnTarget, Quaternion.identity); // GIVE IT LIFE!
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LilGuy")
        {
            Debug.Log("lil guy landed!!");
            SceneManager.LoadScene("GameScene");
            //Destroy(target);
            //Instantiate(target, spawnTarget, Quaternion.identity);

            //score goes up by 1 
            //level resets and spawns target in new position 
        }
    }*/
}
