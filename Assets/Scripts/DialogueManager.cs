using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI Response1;
    public TextMeshProUGUI Response2;
    public TextMeshProUGUI Response3;

    public Animator animator;

    public Queue<string> sentences; //this is built around this being in order

    [SerializeField]
    private float TextDuration = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }


    public void StartDialogue(Dialogue dialogue)
    {
        dialogue.CreatePlayerResponseWithValues();
        //randomize order

        animator.SetBool("IsOpen", true);
        animator.SetBool("LastDialogue", false);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {

            sentences.Enqueue(sentence);

        }

        InitializeResponse();

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

    }

    public void InitializeResponse()
    {

        string sentence = sentences.Dequeue();
        Response1.text = sentence;
        sentence = sentences.Dequeue();
        Response2.text = sentence;
        sentence = sentences.Dequeue();
        Response3.text = sentence;

    }

    public void SelectText1()
    {

        string sentence = sentences.Dequeue();
        sentences.Dequeue();
        sentences.Dequeue();

        dialogueText.text = sentence;

        if (sentences.Count == 0)
        {
            animator.SetBool("LastDialogue", true);

            Invoke("EndDialogue", TextDuration);

            return;
        }

    }

    public void SelectText2()
    {

        sentences.Dequeue();
        string sentence = sentences.Dequeue();
        sentences.Dequeue();
        dialogueText.text = sentence;

        if (sentences.Count == 0)
        {
            animator.SetBool("LastDialogue", true);

            Invoke("EndDialogue", TextDuration);

            return;
        }

    }
    public void SelectText3()
    {

        sentences.Dequeue(); 
        sentences.Dequeue();
        string sentence = sentences.Dequeue();

        dialogueText.text = sentence;

        if (sentences.Count == 0)
        {
            animator.SetBool("LastDialogue", true);

            Invoke("EndDialogue", TextDuration);

            return;
        }

    }

    //check if response = pos neg or neutral response value, call in each SelectText method
    //void EvaluatePlayerResponse(string response)
    //set current_dialogue to last player response dialogue selected

    public void EndDialogue()
    {

        animator.SetBool("IsOpen", false);
        animator.SetBool("LastDialogue", false);

    }

}
