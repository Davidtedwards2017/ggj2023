using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class DialogueBubble : MonoBehaviour
{ 
    public TextTyper typer;
    
    private IEnumerator dialogueSeq;
    public Animator animator;
    public GameObject pressAnyKeyPrompt;
    public SoundEffectData textSound;
    
    public float despawnDelay = 1.0f;
    
    public IEnumerator DialogueSequence(DialogueEntrySO dialogue, bool displayAnyKeyPrompt)
    {
        // pressAnyKeyPrompt.SetActive(false);
        pressAnyKeyPrompt.SetActive(displayAnyKeyPrompt);
        animator.SetBool("show", true);
        yield return typer.PerformTextTyping(dialogue.text, () => textSound.PlaySfx());
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
