using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuGeneralController : MonoBehaviour
{
    public static MenuGeneralController instance;
    [Header("General Buttons")]
    [SerializeField]
    private Button btnMusic;
    [SerializeField]
    private Button btnSound;

    [Header("Init Panel")]
    public GameObject InitPanel;
    [SerializeField]
    private Button btnPlay;
    [SerializeField]
    private Button btnExit;

    [Header("Play Panel")]
    public GameObject PlayPanel;
    [SerializeField]
    private Button btnInfinite;
    [SerializeField]
    private Button btnBack;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        //Botones para cambiar la intensidad de sonido
        btnMusic.onClick.AddListener(() => ChangeMusic());
        Debug.Log(btnMusic.GetComponentInChildren<Text>().text);
        btnMusic.GetComponentInChildren<Text>().text = AudioController.instance.MusicMute ? "Off" : "On";
        btnSound.onClick.AddListener(() => ChangeSound());
        btnSound.GetComponentInChildren<Text>().text = AudioController.instance.SoundMute ? "Off" : "On";

        //Botones principales del Menu
        btnPlay.onClick.AddListener(() => Play());
        btnExit.onClick.AddListener(() => Exit());
        btnInfinite.onClick.AddListener(() => LoadInfinite());
        btnBack.onClick.AddListener(() => Back());


        InitPanel.SetActive(true);
        PlayPanel.SetActive(false);
    }

    void ChangeMusic()
    {
        AudioController.instance.SetMuteMusic();
        btnMusic.GetComponentInChildren<Text>().text = AudioController.instance.MusicMute ? "Off" : "On";
        AudioController.instance.PlayButtonSound();
    }

    void ChangeSound()
    {
        AudioController.instance.SetMuteSound();
        btnSound.GetComponentInChildren<Text>().text = AudioController.instance.SoundMute ? "Off" : "On";
        AudioController.instance.PlayButtonSound();
    }

    public void LoadLevel(int level)
    {
        PlayerPrefs.SetInt("level", level);
        SceneController.instance.ChangeScene("Level");
    }

    void LoadInfinite()
    {
        PlayerPrefs.SetInt("level", 4);
        SceneController.instance.ChangeScene("Infinite");
    }

    void Play()
    {
        InitPanel.SetActive(false);
        PlayPanel.SetActive(true);
        AudioController.instance.PlayButtonSound();
    }

    void Back()
    {
        InitPanel.SetActive(true);
        PlayPanel.SetActive(false);
        AudioController.instance.PlayButtonSound();
    }

    void Exit()
    {
        Application.Quit();
    }


}
