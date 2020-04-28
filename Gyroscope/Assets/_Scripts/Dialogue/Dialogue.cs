using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    [Serializable]
    public struct SentenceCombo
    {
        public string speakerName;
        [TextArea(3, 10)] public string sentence;
    }

    public SentenceCombo[] sentences;

}
