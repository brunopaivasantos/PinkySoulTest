using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HUB : MonoBehaviour
{
    public static HUB Instance;
    Animator anim;

    [SerializeField] Shop shop;
    [SerializeField] Upgrade upgrade;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject shopBackButton;
    [SerializeField] GameObject upgradeBackButton;
    [SerializeField] GameObject upgradeButton;
    [SerializeField] GameObject shopButton;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        OpenHUB();
        anim = this.GetComponent<Animator>();
    }
    public void OpenHUB()
    {
        panel.SetActive(true);

        EventSystem.current.SetSelectedGameObject(playButton);
    }

    public void CloseHUB()
    {
        panel.SetActive(false);
    }

    public void MainMenu()
    {
        GameManager.Instance.MainMenu();
    }

    public void Shop()
    {
        anim.SetTrigger("OpenShop");
        EventSystem.current.SetSelectedGameObject(shopBackButton);
    }

    public void Play()
    {
        GameManager.Instance.Play();
    }

    public void Upgrades()
    {
        anim.SetTrigger("OpenUpgrades");
        EventSystem.current.SetSelectedGameObject(upgradeBackButton);
    }

    public void CloseShop()
    {
        anim.SetTrigger("CloseShop");
        EventSystem.current.SetSelectedGameObject(shopButton);
    }

    public void CloseUpgrades()
    {
        anim.SetTrigger("CloseUpgrades");
        EventSystem.current.SetSelectedGameObject(upgradeButton);
    }
}
