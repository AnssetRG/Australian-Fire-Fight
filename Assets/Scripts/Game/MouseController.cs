using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public static MouseController instance;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100f, 1 << 8);
            if (hit.collider != null)
            {
                Transform t = hit.collider.transform;
                if (t.gameObject.tag == "Australia")
                {
                    Vector3 point = ray.origin + (ray.direction * 4.5f);
                    point.z = 0f;
                    PlayerController.instance.SetTarget(point);
                    PlayerController.instance.ShootWater(point);
                }
            }
        }
    }
}
