using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    #region singleton stuff
    //singleton stuff
    private static DialogueManager instance;
    private DialogueManager() { } //private constructor
    public static DialogueManager GetInstance()
    {
        if (!instance)
            instance = FindObjectOfType<DialogueManager>();
        return instance;
    }
    public void InitSingleton()
    {
        if (instance != null && instance != this)
            Destroy(gameObject); //prevent duplicates in scene
        else
            instance = this;
    }
    #endregion

    private Queue<string> sentences;

    private bool dialogueInProgress;


    private void Awake()
    {
        InitSingleton();
    }

    private void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (dialogueInProgress)
        {
            if (Input.GetAxis("Submit") == 1)
            {
                Debug.Log("next sentence");
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation of length: " + dialogue.sentences.Length);
        sentences.Clear();

        dialogueInProgress = true;

        foreach (Dialogue.SentenceCombo sentenceCombo in dialogue.sentences)
        {
            this.sentences.Enqueue(sentenceCombo.sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0) //end of queue
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log("First sentence is: " + sentence);
    }

    private void EndDialogue()
    {
        Debug.Log("End of conversation");
        dialogueInProgress = false;
    }
}
