using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TraitDisplayer : MonoBehaviour
{
    public TMP_Text text;

    public PortaitMetadataSO startingMetadata;

    private void Awake()
    {
        if (startingMetadata)
        {
            Set(startingMetadata.name, startingMetadata.traits);
        }
    }

    public void Set(string name, List<TraitSO> traits)
    {
        string str = String.Format("Alias: {0}\n", name);
        
        for (int i = 0; i < traits.Count; i ++)
        {
            str += traits[i].displayText;
            if (i < traits.Count - 1) str += "\n";
        }
        
        text.text = str;
    }
}
