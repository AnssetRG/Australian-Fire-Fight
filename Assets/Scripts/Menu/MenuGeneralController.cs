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
        btnMusic.GetComponentInChildren<Text>().text = AudioController.instance.MusicMute ? "Off" : "On";
        btnSound.onClick.AddListener(() => ChangeSound());
        btnSound.GetComponentInChildren<Text>().text = AudioController.instance.SoundMute ? "Off" : "On";

        //Botones principales del Menu
        btnPlay.onClick.AddListener(() => Play());
        btnExit.onClick.AddListener(() => Exit());
        btnInfinite.onClick.AddListener(() => LoadInfinite());
        btnBack.onClick.AddListener(() => Back());

        /*Debug.Log("WIN QUOTES");
        string WinQuotes = JsonFileReader.LoadJsonAsResource("win.json");
        QuoteData quoteData = JsonUtility.FromJson<QuoteData>(WinQuotes);

        foreach (Quote item in quoteData.Quotes)
        {
            print(item.sentence);
        }


        Debug.Log("LOOSE QUOTES");
        string LooseQuotes = JsonFileReader.LoadJsonAsResource("loose.json");
        QuoteData quoteData1 = JsonUtility.FromJson<QuoteData>(LooseQuotes);

        foreach (Quote item in quoteData1.Quotes)
        {
            print(item.sentence);
        }*/


        InitPanel.SetActive(true);
        PlayPanel.SetActive(false);
    }

    void ChangeMusic()
    {
        AudioController.instance.SetMuteMusic();
        btnMusic.GetComponentInChildren<Text>().text = AudioController.instance.MusicMute ? "Off" : "On";
    }

    void ChangeSound()
    {
        AudioController.instance.SetMuteSound();
        btnSound.GetComponentInChildren<Text>().text = AudioController.instance.SoundMute ? "Off" : "On";
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level" + level.ToString());
    }

    void LoadInfinite()
    {
        SceneManager.LoadScene("Infinite");
    }

    void Play()
    {
        InitPanel.SetActive(false);
        PlayPanel.SetActive(true);
    }

    void Back()
    {
        InitPanel.SetActive(true);
        PlayPanel.SetActive(false);
    }

    void Exit()
    {
        Application.Quit();
    }


}
