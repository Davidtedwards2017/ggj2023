using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PortraitSlot))]
public class ResultSlot : MonoBehaviour
{
    public int generation;
    private PortraitSlot slot;
    public List<ResultSlot> parents;
    
    // Start is called before the first frame update
    void Start()
    {
        slot = GetComponent<PortraitSlot>();
    }

    public PortaitMetadataSO getAttachedMetadata()
    {
        return slot.attachedPortrait.portraitMetadata;
    }
    
    public bool IsFilled()
    {
        return slot.AlreadyOccupied();
    }

    public bool ScanTree()
    {
        PortaitMetadataSO attachedPortraitMetadata = getAttachedMetadata();
        if (attachedPortraitMetadata.generation != generation) return false;
        
        if (!parents.Any()) return true;
        
        List<PortaitMetadataSO> validParents = attachedPortraitMetadata.parents;
        foreach (var parent in parents)
        {
            PortaitMetadataSO actualParentMetadata = parent.getAttachedMetadata();
            if (!validParents.Contains(actualParentMetadata)) return false;

            if (!parent.ScanTree()) return false;
        }
        
        return true;
        
        // if (generation == 1)
        // {
        //     
        //     // check parents;
        // }
        // return false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
