using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public DialogueSequenceSO testSequence;
    public DialogueBubble dialogueBubblePrefab;
    public Transform spawnTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunSequence(testSequence));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RunSequence(DialogueSequenceSO seq)
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
