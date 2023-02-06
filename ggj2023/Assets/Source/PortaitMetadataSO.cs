using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Portrait Metadata")]
public class PortaitMetadataSO : ScriptableObject
{
    public string name;
    public string id;
    public Sprite sprite;
    public List<PortaitMetadataSO> parents;
    public int generation = -1;
    public List<TraitSO> traits;
}