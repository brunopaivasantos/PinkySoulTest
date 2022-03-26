using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade Item", menuName = "Upgrade Item")]
public class UpgradeItem : ScriptableObject
{
    public new string name;
    public string description;
    public int cost;
}
