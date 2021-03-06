using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public static bool sfxOn;
    public static bool musicOn;

    #region Inspector
    [SerializeField] private Sound[] sounds;
    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
            LoadSounds();
          
           
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Play(AudioTypes.BGM_MainTheme);
    }

    private void LoadSounds()
    {
        foreach (Sound s in sounds)
        {
            s.CreateAudioSources(gameObject);
        }
    }

    public void Play(AudioTypes type)
    {
        Sound target = Array.Find(sounds, (s) => s.audioType.Equals(type));
        if (target != null)
        {
            target.Play();
        }
    }


    public void ChangeBGMVolume(float volume)
    {
        SoundsByType(SoundType.BGM).ForEach((s) => s.ChangeVolume(volume));
    }

    public void ChangeSFXVolume(float volume)
    {
        SoundsByType(SoundType.SFX).ForEach((s) => s.ChangeVolume(volume));
    }

    public List<Sound> SoundsByType(SoundType type)
    {
        return sounds.Where((s) => s.type.Equals(type)).ToList();
    }

}