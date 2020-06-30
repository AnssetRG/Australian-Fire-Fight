﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireController : MonoBehaviour
{
    public int Life;
    public Color NormalColor;
    public Color PressedColor;
    public Color OverColor;
    public int spawnTime; //lo pude directamente en el levelcontroller pq no sabia si cuando estaba en false en active igual corria el update (no lo use)
    public float despawnTime; //tiempo para que desaparezcan y salga el gameover
    public GameObject singalCanvas;
    public Transform player;
    private void OnMouseDown()
    {
        PlayerController.instance.ShootWater(transform.position);
        Life--;
        GetComponent<SpriteRenderer>().color = PressedColor;
        if (Life < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = NormalColor;
    }

    /// <summary>
    /// Called when the mouse enters the GUIElement or Collider.
    /// </summary>
    void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = OverColor;
    }


    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = NormalColor;
    }

    private void Awake()
    {
        despawnTime = 5f;
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Debug.Log(singalCanvas.transform.localPosition);

    }

    private void Update()
    {
        despawnTime -= Time.deltaTime;

        if (despawnTime <= 0)
        {
            print("perdiste sorry"); //aca haces lo del singleton de game over
        }
        else
        {
            singalCanvas.GetComponentInChildren<Text>().text = ((int)despawnTime).ToString();
        }
        updatePosition();

    }

    void updatePosition()
    {
        Vector3 result = transform.position - player.position;
        if (Vector3.Distance(transform.position, player.position) < 7.5)
        {
            singalCanvas.SetActive(false);
            return;
        }
        singalCanvas.SetActive(true);
        float relationX = result.x / 9f;
        float relationY = result.y / 5.5f;
        float X = returnResult(relationX, -370f, 370f);
        float Y = returnResult(relationY, -190f, 190f);
        singalCanvas.transform.localPosition = new Vector3(X, Y, 0f);
    }

    float returnResult(float relation, float min, float max)
    {
        if (Mathf.Abs(relation) > 1f)
        {
            return relation > 0 ? max : min;
        }
        return relation > 0 ? max * Mathf.Abs(relation) : min * Mathf.Abs(relation);
    }
}
