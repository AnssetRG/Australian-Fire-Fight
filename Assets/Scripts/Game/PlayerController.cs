using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public GameObject ParticleRotator; //lo utilizo para rotar nomas, no sabia como hacerlo rotar asi nomas, asi que use esto sorry por la cochinada
    private bool canMove; //Valida si se puede mover: si está disparando o ya llegó se vuelve falso
    private Vector3 target;
    public static PlayerController instance;
    private Animator animator;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public Rigidbody2D myRB2;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        CameraController.instance.SetPlayer(this.transform);
    }

    void Update()
    {
        if (canMove)
        {
            if (Vector3.Distance(transform.position, target) < 0.001f) canMove = false;
            else
            {
                float step = 5f * Time.deltaTime; // calculate distance to move
                transform.localScale = new Vector3(transform.position.x < target.x ? -0.5f : 0.5f, 0.5f, 0.5f);
                transform.position = Vector3.MoveTowards(transform.position, target, step);
                animator.Play("Walking");
            }

        }
        else
        {
            animator.Play("Idle");
        }
    }


    public void SetTarget(Vector3 newTarget)
    {
        target = newTarget;
        canMove = true;
        /*if (x > transform.position.x)
        {
            ChangeVelocity(new Vector2(2.5f, 0f), -0.5f);
        }
        else
        {
            ChangeVelocity(new Vector2(-2.5f, 0f), 0.5f);
        }*/
    }


    void ChangeVelocity(Vector2 vel, float face)
    {
        CameraController.instance.SetPlayer(this.transform);
        transform.localScale = new Vector3(face, 0.5f, 0.5f);
        myRB2.velocity = vel;
    }

    public void ShootWater(Vector2 pos)
    {
        canMove = false;
        //calcular angle de jugador a fire

        float ang = Mathf.Atan2(pos.y - transform.position.y, pos.x - transform.position.x) * 180 / Mathf.PI;

        //setear angulo
        ParticleRotator.transform.eulerAngles = new Vector3(0f, 0f, ang);
        ParticleRotator.GetComponentInChildren<ParticleSystem>().Play();
    }
}
