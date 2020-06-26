using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public int Life;
    public Color NormalColor;
    public Color PressedColor;
    public int spawnTime;

    private void OnMouseDown()
    {
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
}
