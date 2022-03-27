using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public static Menu Instance;
    Animator anim;

    [SerializeField] GameObject retryButton;
   [SerializeField] Transform panel;
    [SerializeField] TextMeshProUGUI coins;
    private void Awake()
    {
        Instance = this;
        anim = this.GetComponent<Animator>();
    }
   
    public void OpenPopUp()
    {
        coins.text = GameManager.Instance.GetCoins().ToString();
        anim.SetTrigger("Open");
        EventSystem.current.SetSelectedGameObject(retryButton);
    }

    public void Retry()
    {
        GameManager.Instance.Restart();
    }
    public void OpenHUB()
    {
        GameManager.Instance.OpenHUB();
    }

    public void ClosePopUp()
    {
        panel.localScale = Vector3.zero;
    }
}
