using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    [SerializeField] List<ShopItem> itens = new List<ShopItem>();

    [SerializeField] Transform content;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] Button buyButton;
    int coins;
    List<int> shopQuantity = new List<int>();
    int selectedItem = -1;
    void Start()
    {
        SetContent();
    }

    public void SelectButton(int index)
    {
        selectedItem = index;

        description.text = itens[index].description + "\nCost: " + itens[index].cost.ToString(); 
        
    }
    public void SelectItem()
    {
        int diference = coins - itens[selectedItem].cost;

        if (diference > 0)
        {
            buyButton.interactable = true;
            EventSystem.current.SetSelectedGameObject(buyButton.gameObject);
        }
            
        else
            buyButton.interactable = false;
    }

    public void BuyItem()
    {
        int diference = coins - itens[selectedItem].cost;
        coinsText.text = (diference).ToString();
        shopQuantity[selectedItem]++;
        GameManager.Instance.SetShopItemQuantity(shopQuantity);
    }
    void SetContent()
    {
        shopQuantity = GameManager.Instance.GetShopItensQuantity();
        int index = 0;
        foreach (Transform t in content)
        {
            t.GetChild(0).GetComponent<ItemButton>().Setup(index, this);
            t.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = itens[index].name;
            t.GetChild(1).GetComponent<TextMeshProUGUI>().text = shopQuantity[index].ToString();
            index++;

        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
