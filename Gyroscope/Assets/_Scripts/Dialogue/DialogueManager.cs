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
    public float timeBetweenCharacters;

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
    private bool textWritingInProgress;

    private bool textWritingSkipped;

    private bool locked;

    private void Awake()
    {
        InitSingleton();
    }

    private void Start()
    {
        locked = false;
        sentences = new Queue<Dialogue.SentenceCombo>();
    }

    private void Update()
    {
        if (dialogueInProgress && !textWritingInProgress)
        {
            if (Input.GetButtonDown("Submit"))
            {
                
                DisplayNextSentenceDialogue();
            }
        }
        else if (textInProgress && !textWritingInProgress)
        {
            if (Input.GetButtonDown("Submit"))
            {
                EndText();
            }
        }
        else if (textWritingInProgress)
        {
            if (Input.GetButtonDown("Submit"))
            {
                textWritingSkipped = true;
            }
        }
    }

    public void DisplayText(SingleText singleText)
    {
        if (!locked)
        {
            locked = true;
            playerController.controlEnabled = false;
            TextUIParent.gameObject.SetActive(true);
            StartCoroutine(DisplayTextSlow(TextUIText, singleText.text, timeBetweenCharacters));

            textInProgress = true;
        }
    }

    public void EndText()
    {
        locked = false;
        playerController.controlEnabled = true;
        TextUIParent.gameObject.SetActive(false);

        textInProgress = false;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (!locked)
        {
            locked = true;
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
        StartCoroutine(DisplayTextSlow(sentenceText, sentence, timeBetweenCharacters));
    }

    private void EndDialogue()
    {
        locked = false;
        DialogueUIParent.gameObject.SetActive(false);
        dialogueInProgress = false;
        playerController.controlEnabled = true;
    }

    private IEnumerator DisplayTextSlow(TextMeshProUGUI textGUI, string finalText, float waitBetweenCharacters)
    {
        textWritingInProgress = true;

        string intermediateText = "";
        int currentCharacterIndex = -1;

        while (true)
        {
            currentCharacterIndex++;
            if (currentCharacterIndex >= finalText.Length)
            {
                break;
            }
            else
            {
                if (textWritingSkipped)
                {
                    textGUI.SetText(finalText);
                    break;
                }
                intermediateText += finalText[currentCharacterIndex];
                textGUI.SetText(intermediateText);
                yield return new WaitForSeconds(waitBetweenCharacters);
            }
        }

        textWritingInProgress = false;
        textWritingSkipped = false;

        yield return null;
    }
}
