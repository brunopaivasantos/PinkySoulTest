using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{

    public int Coins { get; set; }
    public List<int> shopItemQuantity = new List<int> ();//{ get; set; }
    public int HP { get; set; }
    public float Speed { get; set; }
    public int Jumps { get; set; }

}