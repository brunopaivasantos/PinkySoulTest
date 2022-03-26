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

    private void Awake()
    {
        Instance = this;
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

    }

    public void Shop()
    {

    }

    public void Play()
    {

    }

    public void Upgrades()
    {

    }
}
