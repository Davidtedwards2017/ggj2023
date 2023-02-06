using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class GameplayAnimationController : MonoBehaviour
{
    public Animator animator;

    public SoundEffectData openFolderSfx;
    public SoundEffectData closeFolderSfx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCaseFile(bool value)
    {
        animator.SetBool("casefile_show", value);
        if (value)
        {
            AudioHelper.PlaySfx(openFolderSfx);
        }
        else
        {
            AudioHelper.PlaySfx(closeFolderSfx);
        }
    }
    
}
