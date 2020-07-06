using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class FireController : MonoBehaviour
{
    public int Life;
    public Color NormalColor;
    public Color PressedColor;
    public Color OverColor;
    public int spawnTime; //lo pude directamente en el levelcontroller pq no sabia si cuando estaba en false en active igual corria el update (no lo use)
    public float despawnTime; //tiempo para que desaparezcan y salga el gameover
    public GameObject signalPrefab;
    public GameObject singalCanvas;
    public Transform player;
    public Light2D light;

    protected virtual void OnMouseDown()
    {
        //PlayerController.instance.ShootWater(transform.position);
        Life--;
        GetComponent<SpriteRenderer>().color = PressedColor;
        checkLife();
    }

    public void checkLife()
    {
        if (Life < 0)
        {
            FireGeneralController.instance.FireEliminated();
            Destroy(singalCanvas);
            Destroy(this.gameObject);
        }
    }

    protected virtual void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = NormalColor;
    }

    protected virtual void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = OverColor;
    }

    protected virtual void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = NormalColor;
    }

    private void Awake()
    {
        despawnTime = 25f;
    }

    protected void Start()
    {
        light = this.GetComponentInChildren<Light2D>();
        print(light);
        player = PlayerController.instance.transform;

        if (singalCanvas == null)
        {
            singalCanvas = Instantiate(signalPrefab, Vector3.zero, Quaternion.identity);
            singalCanvas.transform.SetParent(GameObject.Find("Game Canvas").transform);
            singalCanvas.transform.localScale = Vector3.one;
        }
    }

    protected void Update()
    {
        if (GameController.instance.gameEnded) return;

        light.intensity = Mathf.Lerp(0.9f, 1.0f, Mathf.PingPong(Time.time * 5.0f, 1));
        light.pointLightOuterRadius = Mathf.Lerp(5.0f, 6.4f, Mathf.PingPong(Time.time * 2.0f, 1));

        despawnTime -= Time.deltaTime;

        if (despawnTime <= 0)
        {
            GameController.instance.SetResult(false);
            GameController.instance.FireOutMessage(false);
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
        else
        {
            float relation_distance = Vector3.Distance(transform.position, player.position);
            float scale_result = (30 - relation_distance) / 30 < 0.25f ? 0.25f : (30 - relation_distance) / 30;
            singalCanvas.transform.localScale = new Vector3(scale_result, scale_result, 1f);
        }
        singalCanvas.SetActive(true);
        float relationX = result.x / 9f;
        float relationY = result.y / 5.5f;
        float X = returnResult(relationX, -370f, 370f);
        float Y = returnResult(relationY, -190f, 190f);
        singalCanvas.transform.localPosition = new Vector3(X, Y, 0f);
    }

    protected virtual float returnResult(float relation, float min, float max)
    {
        if (Mathf.Abs(relation) > 1f)
        {
            return relation > 0 ? max : min;
        }
        return relation > 0 ? max * Mathf.Abs(relation) : min * Mathf.Abs(relation);
    }
}
