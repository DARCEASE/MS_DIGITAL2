using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

//PURPOSE: Have an obj respond to voice commands 
//USAGE: put this on the object you want to manipulate with ur voice 
public class VoiceCtrlBehavior : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer; //component doing all da work
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    //insert items youd want to mess with so probably like these below
    public GameObject player1;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        //TO DETECT WORDS WITH MICROPHONE - add words to dic 
        actions.Add("Eat Ass", MoveUp);
        actions.Add("Down", MoveDown);

        // now you have to set all these actions as an array and sees if wat u said is here
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void MoveUp()
    {
        // do the thing
        transform.Translate(0, 2, 0);
    }
    private void MoveDown()
    {
        // do the thing
        transform.Translate(0, -2, 0);
    }
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text); // see what keyword it is 
        actions[speech.text].Invoke(); // then it will correlate to the called action
    }

}
