using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public int Coins;
    public List<int> shopItemQuantity;//= new List<int> { 0, 0, 0, 0 };
    public int HP;
    public float Speed;
    public int Jumps;
}