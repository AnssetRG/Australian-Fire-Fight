using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 temp = transform.localScale;
        float width = sr.sprite.bounds.size.x;

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        temp.x = worldScreenWidth / width;
        transform.localScale = temp;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
