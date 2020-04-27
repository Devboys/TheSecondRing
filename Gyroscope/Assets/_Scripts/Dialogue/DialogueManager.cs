using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public Canvas DialogueUIParent;
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI sentenceText;

    public FirstPersonController playerController;

    private Queue<Dialogue.SentenceCombo> sentences;

    private bool dialogueInProgress;


    private void Awake()
    {
        InitSingleton();
    }

    private void Start()
    {
        sentences = new Queue<Dialogue.SentenceCombo>();
    }

    private void Update()
    {
        if (dialogueInProgress)
        {
            if (Input.GetButtonDown("Submit"))
            {
                DisplayNextSentence();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        playerController.controlEnabled = false;

        DialogueUIParent.gameObject.SetActive(true);
        sentences.Clear();

        dialogueInProgress = true;

        foreach (Dialogue.SentenceCombo sentenceCombo in dialogue.sentences)
        {
            this.sentences.Enqueue(sentenceCombo);
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

        Dialogue.SentenceCombo sentenceCombo = sentences.Dequeue();
        string speaker = sentenceCombo.speakerName;
        string sentence = sentenceCombo.sentence;

        speakerText.SetText(speaker);
        sentenceText.SetText(sentence);
    }

    private void EndDialogue()
    {
        DialogueUIParent.gameObject.SetActive(false);
        dialogueInProgress = false;
        playerController.controlEnabled = true;
    }
}
