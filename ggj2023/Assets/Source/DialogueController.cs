using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public DialogueBubble dialogueBubblePrefab;
    public Transform spawnTransform;
    
    public IEnumerator RunSequence(DialogueSequenceSO seq)
    {
        foreach (var dialogueEntry in seq.dialogue)
        {
            yield return ExecuteDialogue(dialogueEntry);
        }
    }

    IEnumerator ExecuteDialogue(DialogueEntrySO entry)
    {
        var bubble = Instantiate(dialogueBubblePrefab, spawnTransform);
        bubble.transform.localPosition = Vector3.zero;

        yield return bubble.DialogueSequence(entry, true);
        yield return new WaitUntil(() => Input.anyKey);
        
        bubble.Despawn();
    }
    
    
}
