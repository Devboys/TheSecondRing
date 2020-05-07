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

    public FirstPersonController playerController;

    [Header("Dialogue UI")]
    public Canvas DialogueUIParent;
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI sentenceText;

    [Header("Text UI")]
    public Canvas TextUIParent;
    public TextMeshProUGUI TextUIText;

    private Queue<Dialogue.SentenceCombo> sentences;
    private bool dialogueInProgress;
    private bool textInProgress;

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
                DisplayNextSentenceDialogue();
            }
        }
        else if (textInProgress)
        {
            if (Input.GetButtonDown("Submit"))
            {
                EndText();
            }
        }
    }

    public void DisplayText(SingleText singleText)
    {
        playerController.controlEnabled = false;
        TextUIParent.gameObject.SetActive(true);
        TextUIText.SetText(singleText.text);

        textInProgress = true;
    }

    public void EndText()
    {
        playerController.controlEnabled = true;
        TextUIParent.gameObject.SetActive(false);

        textInProgress = false;
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

        DisplayNextSentenceDialogue();
    }

    public void DisplayNextSentenceDialogue()
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
