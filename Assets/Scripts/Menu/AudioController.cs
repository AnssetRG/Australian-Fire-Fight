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

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
        MusicMixer.SetFloat("MusicVol", MusicMute ? -80f : 20f);
    }
    public void SetMuteSound()
    {
        SoundMute = !SoundMute;
        SoundMixer.SetFloat("SoundVol", SoundMute ? -80f : 20f);
    }
}