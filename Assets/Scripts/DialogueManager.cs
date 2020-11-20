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
    public TextMeshProUGUI ResponseACCEPT;

    public string NPCDiag;
    public string PlayerResponsePos;
    public string PlayerResponseNeut;
    public string PlayerResponseNeg;
    public string NPCResponsePos;
    public string NPCResponseNeut;
    public string NPCResponseNeg;
    public string NPCOrder;

    public int rand1 = 3;
    public int rand2 = 3;
    public int rand3 = 3;

    public Dialogue dialogueholder;

    public Animator animator;

    public Queue<string> sentences;

    [SerializeField]
    private float TextDuration = 3.0f;

    public void StartDialogue()
    {
        FindObjectOfType<AudioManager>().Play("SkeletonSpeak");
        animator.SetBool("IsOpen", true);
        animator.SetBool("LastDialogue", false);

        nameText.text = dialogueholder.name;

        NumberMixerUpper();

        PlayerResponsePos = dialogueholder.sentences[0];
        PlayerResponseNeut = dialogueholder.sentences[1];
        PlayerResponseNeg = dialogueholder.sentences[2];
        NPCDiag = dialogueholder.sentences[3];
        NPCResponsePos = dialogueholder.sentences[4];
        NPCResponseNeut = dialogueholder.sentences[5];
        NPCResponseNeg = dialogueholder.sentences[6];

        InitializeResponse();
        if (!animator.GetBool("AcceptOrderTrue"))
        {
            dialogueText.text = NPCDiag;
        }

    }

    public void StartOrderDialogue(Dialogue dialogue)
    {
        FindObjectOfType<AudioManager>().Play("SkeletonSpeak");
        animator.SetBool("IsOrder", true);
        animator.SetBool("AcceptOrderTrue", true);

        dialogueholder = dialogue;

        nameText.text = dialogue.name;

        dialogueText.text = "Hey there can I get a " + dialogue.OrderItem;
        ResponseACCEPT.text = dialogue.OrderResponse; 
        
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

    //public void DisplayFirstSentence()
    //{

    //    dialogueText.text = NPCDiag;

    //}

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

        //dialogueText.text = NPCResponsePos;
        /////

        if (rand1 == 1)
        {
            dialogueText.text = NPCResponsePos;
            dialogueValueSelected = DialogueValue.Positive;
            FindObjectOfType<AudioManager>().Play("PositiveAnswer");
        }
        else if (rand1 == 2)
        {
            dialogueText.text = NPCResponseNeut;
            dialogueValueSelected = DialogueValue.Neutral;
            FindObjectOfType<AudioManager>().Play("NeutralAnswer");
        }
        else
        {
            dialogueText.text = NPCResponseNeg;
            dialogueValueSelected = DialogueValue.Negative;
            FindObjectOfType<AudioManager>().Play("NegativeAnswer");
        }

        Debug.Log(dialogueValueSelected);

        /////

        animator.SetBool("LastDialogue", true);

            Invoke("EndDialogueforreal", TextDuration);

            return;

    }

    public void SelectText2()
    {

        /////

        if (rand2 == 1)
        {
            dialogueText.text = NPCResponsePos;
            dialogueValueSelected = DialogueValue.Positive;
            FindObjectOfType<AudioManager>().Play("PositiveAnswer");
        }
        else if (rand2 == 2)
        {
            dialogueText.text = NPCResponseNeut;
            dialogueValueSelected = DialogueValue.Neutral;
            FindObjectOfType<AudioManager>().Play("NeutralAnswer");

        }
        else
        {
            dialogueText.text = NPCResponseNeg;
            dialogueValueSelected = DialogueValue.Negative;
            FindObjectOfType<AudioManager>().Play("NegativeAnswer");
        }

        Debug.Log(dialogueValueSelected);

        /////
        animator.SetBool("LastDialogue", true);

            Invoke("EndDialogueforreal", TextDuration);

            return;

    }
    public void SelectText3()
    {

        /////

        if (rand3 == 1)
        {
            dialogueText.text = NPCResponsePos;
            dialogueValueSelected = DialogueValue.Positive;
            FindObjectOfType<AudioManager>().Play("PositiveAnswer");
        }
        else if (rand3 == 2)
        {
            dialogueText.text = NPCResponseNeut;
            dialogueValueSelected = DialogueValue.Neutral;
            FindObjectOfType<AudioManager>().Play("NeutralAnswer");
        }
        else
        {
            dialogueText.text = NPCResponseNeg;
            dialogueValueSelected = DialogueValue.Negative;
            FindObjectOfType<AudioManager>().Play("NegativeAnswer");
        }

        Debug.Log(dialogueValueSelected);

        /////
        animator.SetBool("LastDialogue", true);

            Invoke("EndDialogueforreal", TextDuration);

            return;

    }

    public void SelectTextAcceptOrder()
    {

        FindObjectOfType<AudioManager>().Play("NeutralAnswer");

        Debug.Log("ACCEPTED ORDER");

        animator.SetBool("AcceptOrderTrue", false);

        //Invoke("EndDialogue", TextDuration);

        EndDialogue();

        return;

    }

    public void EndDialogue()
    {

        animator.SetBool("IsOpen", false);
        animator.SetBool("LastDialogue", false);
        animator.SetBool("IsOrder", false);

        Invoke("StartDialogue", TextDuration);

    }
    public void EndDialogueforreal()
    {

        animator.SetBool("IsOpen", false);
        animator.SetBool("LastDialogue", false);
        //animator.SetBool("IsOrder", false);

    }

}
