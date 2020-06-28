using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Button Left;
    public Button Right;
    public GameObject ParticleRotator; //lo utilizo para rotar nomas, no sabia como hacerlo rotar asi nomas, asi que use esto sorry por la cochinada
    public static PlayerController instance;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(this);
        }            
    }

    public Rigidbody2D myRB2;
    // Start is called before the first frame update
    void Start()
    {
        Left.onClick.AddListener(() => ChangeVelocity(new Vector2(-2.5f, 0f)));
        Right.onClick.AddListener(() => ChangeVelocity(new Vector2(2.5f, 0f)));
    }


    void ChangeVelocity(Vector2 vel)
    {
        myRB2.velocity = vel;
    }

    public void ShootWater(Vector2 pos) {
        //calcular angle de jugador a fire

        float ang = Mathf.Atan2(pos.y - transform.position.y, pos.x - transform.position.x) * 180 / Mathf.PI;

        //setear angulo
        ParticleRotator.transform.eulerAngles = new Vector3(0f, 0f, ang);
        ParticleRotator.GetComponentInChildren<ParticleSystem>().Play();
    }
}
