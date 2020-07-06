using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    [HideInInspector]
    public bool MusicMute;
    [HideInInspector]
    public bool SoundMute;
    [SerializeField]
    private AudioMixer MusicMixer;
    [SerializeField]
    private AudioMixer SoundMixer;

    public AudioSource buttonSound;
    public AudioSource OSTplayer;
    public AudioClip menuTheme;
    public AudioClip gameTheme;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        MusicMute = false;
        SoundMute = false;
    }

    public void SetMuteMusic()
    {
        MusicMute = !MusicMute;
        MusicMixer.SetFloat("MusicVol", MusicMute ? -80f : -20f);
    }
    public void SetMuteSound()
    {
        SoundMute = !SoundMute;
        SoundMixer.SetFloat("SoundVol", SoundMute ? -80f : -20f);
    }

    public void PlayButtonSound()
    {
        buttonSound.Play();
    }

    public void ChangeOst(AudioClip new_theme)
    {
        OSTplayer.Stop();
        OSTplayer.clip = new_theme;
        OSTplayer.Play();
    }
}