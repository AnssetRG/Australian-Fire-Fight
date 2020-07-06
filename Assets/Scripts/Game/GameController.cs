using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject ResultPanel;
    public Button btnMenu;
    public Button btnReset;
    public Text txtResult;
    public GameObject SentencePanel;
    private Animator sentenceAnimator;
    private Text sentenceText;

    public QuoteData winQuoteData;
    public QuoteData looseQuoteData;

    public bool gameEnded;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            gameEnded = false;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        btnMenu.onClick.AddListener(() => { SceneController.instance.ChangeScene("Main Menu"); });
        btnReset.onClick.AddListener(() => { SceneController.instance.ChangeScene(SceneManager.GetActiveScene().name); });
        ResultPanel.SetActive(false);

        string WinQuotes = JsonFileReader.LoadJsonAsResource("win.json");
        winQuoteData = JsonUtility.FromJson<QuoteData>(WinQuotes);

        string LooseQuotes = JsonFileReader.LoadJsonAsResource("loose.json");
        looseQuoteData = JsonUtility.FromJson<QuoteData>(LooseQuotes);

        sentenceText = SentencePanel.GetComponentInChildren<Text>();
        sentenceAnimator = SentencePanel.GetComponent<Animator>();
    }

    public void FireOutMessage(bool on)
    {
        string sentence;
        int rand_n;
        if (on)
        {
            rand_n = Random.Range(0, winQuoteData.Quotes.Count);
            sentence = winQuoteData.Quotes[rand_n].sentence;
        }
        else
        {
            rand_n = Random.Range(0, winQuoteData.Quotes.Count);
            sentence = looseQuoteData.Quotes[rand_n].sentence;
        }
        sentenceText.text = sentence;
        sentenceAnimator.Play("QuoteEnter");
        StartCoroutine(SentenceOut());
    }

    public void SetResult(bool win)
    {
        ResultPanel.SetActive(true);
        txtResult.text = win ? "GANASTE" : "PERDISTE";
        gameEnded = true;
    }

    IEnumerator SentenceOut()
    {
        yield return new WaitForSeconds(5.0f);
        sentenceAnimator.Play("QuoteOut");
    }

}