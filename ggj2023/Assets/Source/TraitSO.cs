using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Trait")]
public class TraitSO : ScriptableObject
{
    public List<QuipSO> quips;
}
