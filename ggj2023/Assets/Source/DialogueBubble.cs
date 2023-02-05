using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBubble : MonoBehaviour
{ 
    public TextTyper typer;
    
    private IEnumerator dialogueSeq;
    public Animator animator;
    public GameObject pressAnyKeyPrompt;
    
    public float despawnDelay = 1.0f;
    
    public IEnumerator DialogueSequence(DialogueEntrySO dialogue, bool displayAnyKeyPrompt)
    {
        // pressAnyKeyPrompt.SetActive(false);
        pressAnyKeyPrompt.SetActive(displayAnyKeyPrompt);
        animator.SetBool("show", true);
        yield return typer.PerformTextTyping(dialogue.text);
        if (displayAnyKeyPrompt)
        {
            yield return pressAnyKeyPrompt.GetComponent<TextTyper>().PerformTextTyping("Press any key...");
        }
    }

    public void Despawn()
    {
        animator.SetBool("show", false);
        Destroy(gameObject, despawnDelay);
    }
    
}
