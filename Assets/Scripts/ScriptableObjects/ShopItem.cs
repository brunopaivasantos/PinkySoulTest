using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Shop Item", menuName = "ShopItem")]
public class ShopItem : ScriptableObject
{
    public new string name;
    public string description;
    public int cost;
  
}
