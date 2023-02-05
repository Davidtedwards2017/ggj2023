using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/entry")]
public class DialogueEntrySO : ScriptableObject
{
    [Multiline]
    public string text;
}
