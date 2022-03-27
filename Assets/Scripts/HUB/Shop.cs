using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<ShopItem> itens = new List<ShopItem>();

    [SerializeField] protected Transform content;
    [SerializeField] protected TextMeshProUGUI description;
    [SerializeField] protected TextMeshProUGUI coinsText;
    [SerializeField] protected Button buyButton;
    protected int coins;
    private List<int> shopQuantity = new List<int>();
    protected List<Button> itembuttons = new List<Button>();
    protected int selectedItem = -1;
    protected virtual void Start()
    {
        SetContent();
    }

    public virtual void SelectButton(int index)
    {
       // selectedItem = index;

        description.text = itens[index].description + "\nCost: " + itens[index].cost.ToString();

    }
    public virtual void SelectItem(int index)
    {
        selectedItem = index;
        int diference = coins - itens[selectedItem].cost;

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

    public virtual void BuyItem()
    {
        int diference = coins - itens[selectedItem].cost;
        coins = diference;
        coinsText.text = (diference).ToString();
        shopQuantity[selectedItem]++;
        itembuttons[selectedItem].transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>().text = shopQuantity[selectedItem].ToString(); ;
        GameManager.Instance.SetShopItemQuantity(shopQuantity);

        GameManager.Instance.SetCoins(coins);

        SelectItem(selectedItem);
    }
    protected virtual void SetContent()
    {
        coins = GameManager.Instance.GetCoins();
        coinsText.text = coins.ToString();

        shopQuantity = GameManager.Instance.GetShopItensQuantity();
        int index = 0;
        foreach (Transform t in content)
        {
            t.GetChild(0).GetComponent<ItemButton>().Setup(index, this);
            t.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = itens[index].name;
            t.GetChild(1).GetComponent<TextMeshProUGUI>().text = shopQuantity[index].ToString();

            Debug.Log("shopQuantity" + shopQuantity[index]);
            itembuttons.Add(t.GetChild(0).GetComponent<Button>());
            itembuttons[index].transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>().text = shopQuantity[index].ToString();
            index++;

        }
        itembuttons.ForEach(b => b.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black);
        buyButton.interactable = false;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
