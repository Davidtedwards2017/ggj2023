using System.Collections;
using System.Collections.Generic;
using Spine;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Portrait : MonoBehaviour
{
    public PortaitMetadataSO portraitMetadata;
    public PortraitEventSO requestReturnToCaseFileSO;
    public float moveSpeed = 5.0f;

    public TMP_Text text;
    public SpriteRenderer portraitSprite;
    void Start()
    {
        
    }

    public void Init(PortaitMetadataSO metadata)
    {
        portraitMetadata = metadata;
        text.text = portraitMetadata.id;
        portraitSprite.sprite = portraitMetadata.sprite;
    }

    public void DragPosition(Vector3 position)
    {
        transform.position = position;
    }
    
    
    public void PutBackInCaseFile()
    {
        requestReturnToCaseFileSO.Raise(this);
    }

    public void MoveToSlot(PortraitSlot slot)
    {
        transform.DOMove(slot.transform.position, moveSpeed)
            .SetSpeedBased();
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
