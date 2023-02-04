using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitInitializer : MonoBehaviour
{
    public SimpleEventSO portraitsInitializedEventSO;
    public List<PortaitMetadataSO> metadata;
    public Portrait prefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            DestroyImmediate(child.gameObject);
        }
        
        foreach (var portraitMetadata in metadata)
        {
            Portrait instance = Instantiate(prefab, transform);
            instance.gameObject.SetActive(false);
            instance.Init(portraitMetadata);
        }
        
        portraitsInitializedEventSO.Raise();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
