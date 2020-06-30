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

    void Awake()
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
    void Start()
    {
        btnMenu.onClick.AddListener(() => { SceneManager.LoadScene("Main Menu"); });
        btnReset.onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().name); });
        ResultPanel.SetActive(false);
    }

    public void SetResult(bool win)
    {
        ResultPanel.SetActive(true);
        txtResult.text = win ? "GANASTE" : "PERDISTE";
    }


}
