using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    [SerializeField] Transform lifeContent;
    [SerializeField] TextMeshProUGUI jumpsText;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] Image coinImage;
    List<Image> lifes = new List<Image>();
    public void UpdateCoins(int coins)
    {
        coinsText.text = "x " + coins.ToString();
    }

    public void UpdateTotalLife(int life)
    {
        Image lifeImage = lifeContent.GetChild(0).GetComponent<Image>();
        lifes.Add(lifeImage);
        for (int i = 0; i < life - 1; i++)
        {
            Image l = Instantiate(lifeImage, lifeContent);
            lifes.Add(l);
        }
    }

    public void UpdateJumps(int jumps)
    {
        jumpsText.text = "Jumps: " + jumps;
    }

    public void DecreaseLife(int life)
    {
        lifes[life].color = Color.gray;
    }

    public void NoJumpAnimation()
    {
        this.GetComponent<Animator>().Play("NoJump", -1, 0);
    }
}
