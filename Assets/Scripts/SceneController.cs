using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public static SceneController instance { get; private set; }
    public Canvas canvas;
    public Animator animator;
    private string level_to_load;
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
    }


    void Start()
    {
        canvas.worldCamera = Camera.main;
    }

    public void ChangeScene(string level_to_load)
    {
        AudioController.instance.PlayButtonSound();
        animator.Play("FadeOut");
        this.level_to_load = level_to_load;
    }

    public void FadeIn()
    {
        Debug.Log("Play fade in");
        animator.Play("FadeIn");
    }

    //Cuando se termine de cargar la escena, se muestra y se reproduce un nuevo tema
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(level_to_load);
        FadeIn();
        switch (level_to_load)
        {
            case "Menu Principal":
                AudioController.instance.ChangeOst(AudioController.instance.menuTheme);
                break;
            case "World":
                AudioController.instance.ChangeOst(AudioController.instance.gameTheme);
                break;
        }

    }


}