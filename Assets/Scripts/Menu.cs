using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public static Menu Instance;
    Animator anim;

    [SerializeField] GameObject retryButton;
   [SerializeField] Transform panel;
    private void Awake()
    {
        Instance = this;
        anim = this.GetComponent<Animator>();
    }
   
    public void OpenPopUp()
    {
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
