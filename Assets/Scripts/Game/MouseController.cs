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
            Debug.Log("Apretado");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
                Debug.Log(transform.position);
        }
    }
}
