using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
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
    [SerializeField] PlayableDirector credits;
    [SerializeField] GameObject creditsButton;

    bool playingCredits;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        EventSystem.current.SetSelectedGameObject(playButton);
        SetMusicVolume();
        SetSFXVolume();
    }

    private void Update()
    {
        if (playingCredits)
        {
            if(Input.anyKey)
            {
                EndCredits();
            }
        }
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

    //Options-------------------------------------

    public void ChangeMusicVolume()
    {
        float volume = music.value;
        SoundManager.Instance.ChangeBGMVolume(volume);
        GameManager.Instance.SetMusicVolume(volume);
    }

    public void SetMusicVolume()
    {
        music.value = GameManager.Instance.GetMusicVolume();
        SoundManager.Instance.ChangeBGMVolume(music.value);
    }

    public void ChangeSFXVolume()
    {
        float volume = sfx.value;
        SoundManager.Instance.ChangeSFXVolume(volume);
        GameManager.Instance.SetSFXVolume(volume);
    }

    public void SetSFXVolume()
    {
        sfx.value = GameManager.Instance.GetSFXVolume();
        SoundManager.Instance.ChangeSFXVolume(sfx.value);
    }

    public void SetResolution()
    {
        Enums.Resolution res = (Enums.Resolution)resolution.value;
        switch (res)
        {
            case Enums.Resolution.Lower:
                Screen.SetResolution(1024, 576, fullScreen.isOn);
                break;

            case Enums.Resolution.WXGA:
                Screen.SetResolution(1366, 768, fullScreen.isOn);
                break;

            case Enums.Resolution.FHD:
                Screen.SetResolution(1920, 1080, fullScreen.isOn);
                break;

            case Enums.Resolution.QHD:
                Screen.SetResolution(2560, 1440, fullScreen.isOn);
                break;

            case Enums.Resolution.UHD:
                Screen.SetResolution(3840, 2160, fullScreen.isOn);
                break;
        }

   
    }

    public void SetFullScreen()
    {
        Screen.fullScreen = fullScreen.isOn;
    }

    public void Credits()
    {
        credits.gameObject.SetActive(true);
        playingCredits = true;
        credits.Play();
        credits.stopped += EndCredits;
    }

    public void EndCredits(PlayableDirector credits)
    {
        
        EventSystem.current.SetSelectedGameObject(creditsButton);
        playingCredits = false;
        credits.stopped -= EndCredits;
        credits.gameObject.SetActive(false);
    }

    public void EndCredits()
    {
        credits.Stop();
    }
}
