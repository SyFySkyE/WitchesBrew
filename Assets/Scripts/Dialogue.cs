using UnityEngine;

public enum DialogueValue {Positive, Neutral, Negative};

public class PlayerResponse
{
    public string text;
    DialogueValue value;

    public PlayerResponse(string text, DialogueValue value)
    {
        this.text = text;
        this.value = value;
    }
}


[System.Serializable]
public class Dialogue
{
    public PlayerResponse positiveResponse, negativeResponse, neutralResponse;
    public DialogueValue dialogueValueSelected;
    public string name;

    [TextArea(3, 10)]
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

    public void CreatePlayerResponseWithValues()
    {
        positiveResponse = new PlayerResponse(sentences[0], DialogueValue.Positive);
        negativeResponse = new PlayerResponse(sentences[1], DialogueValue.Negative);
        neutralResponse = new PlayerResponse(sentences[2], DialogueValue.Neutral);

    }

}

