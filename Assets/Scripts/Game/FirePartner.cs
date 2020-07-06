using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePartner : MonoBehaviour
{
    public Color NormalColor;
    public Color PressedColor;
    public Color OverColor;
    public FireController father;
    void OnMouseDown()
    {
        //PlayerController.instance.ShootWater(transform.position);
        father.Life--;
        GetComponent<SpriteRenderer>().color = PressedColor;
        father.checkLife();
    }

    void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = NormalColor;
    }

    void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = OverColor;
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = NormalColor;
    }
}
