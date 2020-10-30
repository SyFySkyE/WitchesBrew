using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DialogueValue { Positive, Neutral, Negative };

public class PlayerResponse
{
    public string text;
    DialogueValue value;

    public PlayerResponse(string text, DialogueValue value)
    {
        this.value = value;
    }
}

[System.Serializable]
public class Dialogue
{

    public string name;

    [TextArea(3,10)]
    public string[] sentences;


    // note formating here:
    //
    // Player response 1 Positive
    // Player response 2 Neutral 
    // Player Response 3 Negative
    // The original Question or text from the NPC
    // NPC Response to 1
    // NPC Response to 2
    // NPC Response to 3

}
