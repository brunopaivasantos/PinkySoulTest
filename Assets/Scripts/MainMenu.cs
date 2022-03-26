using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Animator anim;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject optionsButton;
    [SerializeField] Slider music;
    [SerializeField] Slider sfx;
    [SerializeField] TMP_Dropdown resolution;
    [SerializeField] Toggle fullScreen;
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(playButton);
    }

    public void Play()
    {
        GameManager.Instance.Play();
    }

    public void Options()
    {
        
        anim.SetTrigger("Open");
        EventSystem.current.SetSelectedGameObject(backButton);
    }

    public void CloseOptions()
    {
        anim.SetTrigger("Close");
        GameManager.Instance.Save();
        EventSystem.current.SetSelectedGameObject(optionsButton);
    }

    public void Quit()
    {
        Application.Quit();
    }


}
