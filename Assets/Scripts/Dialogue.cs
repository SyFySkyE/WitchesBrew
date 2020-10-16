using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Dialogue
{

    public string name;

    [TextArea(3,10)]
    public string[] sentences;

    // note formating here:
    //
    // Player response 1
    // Player response 2
    // Player Response 3
    // The original Question or text from the NPC
    // NPC Response to 1
    // NPC Response to 2
    // NPC Response to 3

}
