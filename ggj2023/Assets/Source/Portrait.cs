using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.Events;

public class Portrait : MonoBehaviour
{
    public SimpleEventSO clearAllEventSO;
    public PortaitMetadataSO portraitMetadata;
    public PortraitEventSO requestReturnToCaseFileSO;
    public PortraitEventSO portraitDestroyedEventSO;
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

    private void OnEnable()
    {
        clearAllEventSO.Event.AddListener(OnClearAll);
    }

    private void OnDisable()
    {
        clearAllEventSO.Event.RemoveListener(OnClearAll);
    }

    private void OnClearAll()
    {
        DestroyImmediate(gameObject);
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

    private void OnDestroy()
    {
        portraitDestroyedEventSO.Raise(this);
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
