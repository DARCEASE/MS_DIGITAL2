using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

//PURPOSE: Have an obj respond to voice commands + properties of this boulder

//USAGE: put this on the object you want to manipulate with ur voice // aka player
public class VoiceCtrlBehavior : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer; //component doing all da work
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    //insert items youd want to mess with so probably like these below
    public GameObject bird; // to detect collisions
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        //TO DETECT WORDS WITH MICROPHONE - add words to dic 
        actions.Add("Move Up", MoveUp);
        actions.Add("Move Down", MoveDown);
        actions.Add("Move Left", MoveLeft);
        actions.Add("Move Right", MoveRight);
        actions.Add("Drop", Drop);

        // now you have to set all these actions as an array and sees if wat u said is here
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bird")
        {
            Destroy(bird);
            SceneManager.LoadScene("GameScene");
            //restart the scene and the player gets no points 
        }
        if (collision.gameObject.tag == "target")
        {
            Debug.Log("PLEASE FOR THE LOVE OF GOD DETECT THIS");
        }
    }
    private void MoveUp()
    {
        // do the thing
        transform.Translate(0, 1, 0);
    }
    private void MoveDown()
    {
        // do the thing
        transform.Translate(0, -1, 0);
    }
    private void MoveLeft()
    {
        // do the thing
        transform.Translate(-1, 0, 0);
    }
    private void MoveRight()
    {
        // do the thing
        transform.Translate(1, 0, 0);
    }
    private void Drop()
    {
        // do the thing
        GetComponent<Rigidbody2D>().gravityScale = 3;
    }
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text); // see what keyword it is 
        actions[speech.text].Invoke(); // then it will correlate to the called action
    }
     
    
    
       
    

}
