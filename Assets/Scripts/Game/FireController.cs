using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public int Life;
    public Color NormalColor;
    public Color PressedColor;
    public int spawnTime; //lo pude directamente en el levelcontroller pq no sabia si cuando estaba en false en active igual corria el update (no lo use)
    public float despawnTime; //tiempo para que desaparezcan y salga el gameover

    private void OnMouseDown()
    {
        PlayerController.instance.ShootWater(transform.position);
        Life--;
        GetComponent<SpriteRenderer>().color = PressedColor;
        if (Life < 0) {
            Destroy(this.gameObject);
        }
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = NormalColor;
    }

    private void Awake()
    {
        despawnTime = 5f;
    }

    private void Update()
    {
        despawnTime -= Time.deltaTime;        
        if (despawnTime <= 0) {
            print("perdiste sorry"); //aca haces lo del singleton de game over
        }

    }
}
