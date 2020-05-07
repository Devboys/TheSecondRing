using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SingleText", menuName = "Narrative/SingleText")]
public class SingleText : ScriptableObject
{

    [TextArea(3, 10)] public string text;

}
