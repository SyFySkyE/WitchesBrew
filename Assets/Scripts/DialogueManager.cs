using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    public Queue<string> sentences;

    [SerializeField]
    private float TextDuration = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {

            sentences.Enqueue(sentence);

        }

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

    public void SelectText1()
    {

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

        itsTimer();

        EndDialogue();

    }

    private IEnumerator itsTimer()
    {

        yield return new WaitForSeconds(TextDuration);

    }

    void EndDialogue()
    {

        animator.SetBool("IsOpen", false);

    }

}
