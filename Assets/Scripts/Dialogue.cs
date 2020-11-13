using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DialogueValue { Positive, Neutral, Negative };

[System.Serializable]
public class Dialogue
{

    public string name;
    public string OrderItem;
    public string OrderResponse;

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
