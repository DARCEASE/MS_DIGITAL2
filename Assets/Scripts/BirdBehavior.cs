using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PURPOSE: make bird move and also detect collision 
//USAGE: PLACE ON BIRD GAMEOBJECT
public class BirdBehavior : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //always move forward (along x axis)
        transform.Translate(speed * Time.deltaTime, 0f, 0f); //move 2m a second
    }
   
}
