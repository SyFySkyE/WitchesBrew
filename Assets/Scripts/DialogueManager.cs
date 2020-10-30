using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public DialogueValue dialogueValueSelected;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI Response1;
    public TextMeshProUGUI Response2;
    public TextMeshProUGUI Response3;

    public string NPCDiag;
    public string PlayerResponsePos;
    public string PlayerResponseNeut;
    public string PlayerResponseNeg;
    public string NPCResponsePos;
    public string NPCResponseNeut;
    public string NPCResponseNeg;

    public int rand1 = 0;
    public int rand2 = 0;
    public int rand3 = 0;

    public Animator animator;

    public Queue<string> sentences;

    [SerializeField]
    private float TextDuration = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        //sentences = new Queue<string>();

    }

    public void StartDialogue(Dialogue dialogue)
    {

        animator.SetBool("IsOpen", true);
        animator.SetBool("LastDialogue", false);

        nameText.text = dialogue.name;

        //sentences.Clear();

        NumberMixerUpper();

        PlayerResponsePos = dialogue.sentences[0];
        PlayerResponseNeut = dialogue.sentences[1];
        PlayerResponseNeg = dialogue.sentences[2];
        NPCDiag = dialogue.sentences[3];
        NPCResponsePos = dialogue.sentences[4];
        NPCResponseNeut = dialogue.sentences[5];
        NPCResponseNeg = dialogue.sentences[6];

        InitializeResponse();

        DisplayFirstSentence();

    }

    public void NumberMixerUpper()
    {

        //Random random = new Random();

        rand1 = Random.Range(1,4);

        if (rand1 == 1)
        {
            rand2 = Random.Range(2,4);
            if (rand2 == 2)
            {
                rand3 = 3;
            }
            else
            {
                rand3 = 2;
            }
        }
        else if (rand1 == 2)
        {
            rand2 = Random.Range(1,4);
            if (rand2 == 2)
                rand2 = 1;
            if (rand2 == 1)
            {
                rand3 = 3;
            }
            else
            {
                rand3 = 1;
            }
        }
        else
        {
            rand2 = Random.Range(1,3);
            if (rand2 == 1)
            {
                rand3 = 2;
            }
            else
            {
                rand3 = 1;
            }
        }

    }

    public void DisplayFirstSentence()
    {

        //if (sentences.Count == 0)
        //{
        //    EndDialogue();
        //    return;
        //}

        //string sentence = sentences.Dequeue();
        dialogueText.text = NPCDiag;

    }

    public void InitializeResponse()
    {

        //string sentence = sentences.Dequeue();
        //Response1.text = sentence;
        //sentence = sentences.Dequeue();
        //Response2.text = sentence;
        //sentence = sentences.Dequeue();
        //Response3.text = sentence;

        //Response1.text = PlayerResponsePos;
        //Response2.text = PlayerResponseNeut;
        //Response3.text = PlayerResponseNeg;

        if (rand1 == 1)
        {
            Response1.text = PlayerResponsePos;
        }
        else if (rand1 == 2)
        {
            Response1.text = PlayerResponseNeut;
        }
        else
        {
            Response1.text = PlayerResponseNeg;
        }
        /////
        if (rand2 == 1)
        {
            Response2.text = PlayerResponsePos;
        }
        else if (rand2 == 2)
        {
            Response2.text = PlayerResponseNeut;
        }
        else
        {
            Response2.text = PlayerResponseNeg;
        }
        /////
        if (rand3 == 1)
        {
            Response3.text = PlayerResponsePos;
        }
        else if (rand3 == 2)
        {
            Response3.text = PlayerResponseNeut;
        }
        else
        {
            Response3.text = PlayerResponseNeg;
        }

    }

    public void SelectText1()
    {

        dialogueText.text = NPCResponsePos;

        /////
        
        if (rand1 == 1)
        {
            dialogueText.text = NPCResponsePos;
            dialogueValueSelected = DialogueValue.Positive;
        }
        else if (rand1 == 2)
        {
            dialogueText.text = NPCResponseNeut;
            dialogueValueSelected = DialogueValue.Neutral;
        }
        else
        {
            dialogueText.text = NPCResponseNeg;
            dialogueValueSelected = DialogueValue.Negative;
        }
        
        /////

        animator.SetBool("LastDialogue", true);

            Invoke("EndDialogue", TextDuration);

            return;

    }

    public void SelectText2()
    {

        /////

        if (rand2 == 1)
        {
            dialogueText.text = NPCResponsePos;
            dialogueValueSelected = DialogueValue.Positive;
        }
        else if (rand2 == 2)
        {
            dialogueText.text = NPCResponseNeut;
            dialogueValueSelected = DialogueValue.Neutral;

        }
        else
        {
            dialogueText.text = NPCResponseNeg;
            dialogueValueSelected = DialogueValue.Negative;
        }

        /////
        animator.SetBool("LastDialogue", true);

            Invoke("EndDialogue", TextDuration);

            return;

    }
    public void SelectText3()
    {

        /////

        if (rand3 == 1)
        {
            dialogueText.text = NPCResponsePos;
            dialogueValueSelected = DialogueValue.Positive;
        }
        else if (rand3 == 2)
        {
            dialogueText.text = NPCResponseNeut;
            dialogueValueSelected = DialogueValue.Neutral;
        }
        else
        {
            dialogueText.text = NPCResponseNeg;
            dialogueValueSelected = DialogueValue.Negative;
        }

        Debug.Log(dialogueValueSelected);

        /////
        animator.SetBool("LastDialogue", true);

            Invoke("EndDialogue", TextDuration);

            return;

    }

    public void EndDialogue()
    {

        animator.SetBool("IsOpen", false);
        animator.SetBool("LastDialogue", false);

    }

}
