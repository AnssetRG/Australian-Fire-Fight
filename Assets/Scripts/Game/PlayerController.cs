using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Button Left;
    public Button Right;

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
}
