using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemButton : MonoBehaviour, ISelectHandler
{
    int index;
    Shop shop;
    public void OnSelect(BaseEventData eventData)
    {
        shop.SelectButton(index);

    }

    public void Setup(int i, Shop shop)
    {
        index = i;
        this.shop = shop;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
