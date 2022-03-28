using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Upgrade : Shop
{
    Enums.Upgrade upgradeType;
    [SerializeField] private List<UpgradeItem> upgradeItens = new List<UpgradeItem>();
    private int hp;
    private float speed;
    private int jumps;
    [SerializeField] private int maxHp;
    [SerializeField] private float maxSpeed;
    [SerializeField] private int maxJumps;
    [SerializeField] private TextMeshProUGUI hpTextQuantity;
    [SerializeField] private TextMeshProUGUI speedTextQuantity;
    [SerializeField] private TextMeshProUGUI jumpsTextQuantity;

    // Start is called before the first frame update
    protected override void Start()
    {
        SetContent();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void SelectButton(int index)
    {
        // selectedItem = index;

        description.text = upgradeItens[index].description + "\nCost: " + upgradeItens[index].cost.ToString();

    }
    public override void SelectItem(int index)
    {
        selectedItem = index;
        upgradeType = (Enums.Upgrade)index;
        if (CheckMax())
        {
            buyButton.interactable = false;
            EventSystem.current.SetSelectedGameObject(itembuttons[selectedItem].gameObject);
            return;
        }
        int diference = coins - upgradeItens[selectedItem].cost;

        if (diference >= 0)
        {
            buyButton.interactable = true;
            EventSystem.current.SetSelectedGameObject(buyButton.gameObject);
        }

        else
        {

            buyButton.interactable = false;
            EventSystem.current.SetSelectedGameObject(itembuttons[selectedItem].gameObject);
        }

        itembuttons.ForEach(b => b.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black);
        itembuttons[selectedItem].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.blue;
    }
    public override void BuyItem()
    {
        int diference = coins - upgradeItens[selectedItem].cost;
        coins = diference;
        coinsText.text = (diference).ToString();
        //GameManager.Instance.SetUpgradeItemQuantity(upgradeQuantity);
        SaveNewItem();
        GameManager.Instance.SetCoins(coins);

        SelectItem(selectedItem);
    }

    void SaveNewItem()
    {

        switch (upgradeType)
        {
            case Enums.Upgrade.hp:
                hp++;
                hpTextQuantity.text = hp.ToString();
                if (hp >= maxHp)
                {
                    hpTextQuantity.text = maxHp + "(Max)";

                }
                GameManager.Instance.SetHP(hp);
                break;

            case Enums.Upgrade.speed:
                speed = 2 * speed;
                speedTextQuantity.text = speed.ToString("F1");
                if (speed >= maxSpeed)
                {
                    speedTextQuantity.text = maxSpeed.ToString("F1") + ("Max");
                }
                GameManager.Instance.SetSpeed(speed);
                break;

            case Enums.Upgrade.jumps:
                jumps += 10;
                jumpsTextQuantity.text = jumps.ToString();
                if (jumps >= maxJumps)
                {
                    jumpsTextQuantity.text = maxJumps + "(Max)";

                }
                GameManager.Instance.SetJumps(jumps);
                break;
        }

    }

    bool CheckMax()
    {
        switch (upgradeType)
        {
            case Enums.Upgrade.hp:
                return hp >= maxHp;

            case Enums.Upgrade.speed:
                return speed >= maxSpeed;

            case Enums.Upgrade.jumps:
                return jumps >= maxJumps;

        }
        return false;
    }

    protected override void SetContent()
    {
        coins = GameManager.Instance.GetCoins();
        coinsText.text = coins.ToString();

        // upgradeQuantity = GameManager.Instance.GetShopItensQuantity();
        hp = GameManager.Instance.GetHP();
        speed = GameManager.Instance.GetSpeed();
        jumps = GameManager.Instance.GetJumps();

        hpTextQuantity.text = hp.ToString();
        speedTextQuantity.text = speed.ToString("F1");
        jumpsTextQuantity.text = jumps.ToString();

        if (hp >= maxHp)
        {
            hpTextQuantity.text = maxHp + "(Max)";

        }
        if (speed >= maxSpeed)
        {
            speedTextQuantity.text = maxSpeed.ToString("F1") + ("Max");
        }
        if (jumps >= maxJumps)
        {
            jumpsTextQuantity.text = maxJumps + "(Max)";

        }

        int index = 0;
        foreach (Transform t in content)
        {
            t.GetChild(0).GetComponent<ItemButton>().Setup(index, this);

            if (index == 0)
                t.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = upgradeItens[index].name;



            itembuttons.Add(t.GetChild(0).GetComponent<Button>());
            index++;

        }
        itembuttons.ForEach(b => b.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black);
        buyButton.interactable = false;
    }
}
