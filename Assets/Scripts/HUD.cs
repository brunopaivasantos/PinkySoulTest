using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    [SerializeField] Transform lifeContent;
    [SerializeField] TextMeshProUGUI jupmsText;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] Image coinImage;
   
    public void UpdateCoins(int coins)
    {
        coinsText.text = coins.ToString();
    }

    public void UpdateLife(int life)
    {
        
    }
}
