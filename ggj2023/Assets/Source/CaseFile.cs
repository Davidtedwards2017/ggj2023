using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilites;

public class CaseFile : Singleton<CaseFile>
{
    public PortraitEventSO requestReturnToCaseFileSO;
    public SimpleEventSO portraitsInitializedEventSO;

    public Transform portraitsContainer;
    public List<PortraitSlot> slots;
    public List<Portrait> portraits;

    private FilteredRandom<PortraitSlot> randSlots;


    private bool requestSeedPortraits = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        randSlots = new FilteredRandom<PortraitSlot>(slots, 3);
        portraitsInitializedEventSO.Event.AddListener(OnPortraitsInitialized);
        requestReturnToCaseFileSO.Event.AddListener(OnRequestReturnToCaseFile);
        
        SeedPortaits();
    }

    private void OnDisable()
    {
        portraitsInitializedEventSO.Event.RemoveListener(OnPortraitsInitialized);
        requestReturnToCaseFileSO.Event.RemoveListener(OnRequestReturnToCaseFile);
    }

    private void OnPortraitsInitialized()
    {
        requestSeedPortraits = true;
    }

    private void OnRequestReturnToCaseFile(Portrait portrait)
    {
        PortraitSlot slot = randSlots.GetNextRandom();
        while (slot.AlreadyOccupied())
        {
            slot = randSlots.GetNextRandom();
        }

        slot.Attach(portrait);
    }

    // Update is called once per frame
    void Update()
    {
        if (requestSeedPortraits)
        {
            SeedPortaits();
            requestSeedPortraits = false;
        }
    }

    void SeedPortaits()
    {
        portraits = portraitsContainer.GetComponentsInChildren<Portrait>(true).ToList();
        foreach (var portrait in portraits)
        {
            while (true)
            {
                PortraitSlot slot = randSlots.GetNextRandom();
                if (!slot.AlreadyOccupied())
                {
                    portrait.transform.position = slot.transform.position;
                    portrait.gameObject.SetActive(true);
                    slot.Attach(portrait);
                    break;
                }
                
            }
        }
    }
}
