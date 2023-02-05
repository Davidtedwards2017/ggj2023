using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Sequence")]
public class DialogueSequenceSO : ScriptableObject
{
    public List<DialogueEntrySO> dialogue;
}
