using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [HideInInspector]
    public Vector3 startPosition;
    private float minCameraX = 0f, maxCameraX = 14f;

    [HideInInspector]
    public bool isFollowing;
    [HideInInspector]
    public Transform playerToFollow;
    public static CameraController instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            /*Vector3 birdPosition = playerToFollow.position;
            float x = Mathf.Clamp(birdPosition.x, minCameraX, maxCameraX);
            transform.position = new Vector3(x, startPosition.y, startPosition.z);*/
            transform.position = new Vector3(playerToFollow.position.x, playerToFollow.position.y, transform.position.z);
        }
    }

    public void SetPlayer(Transform player)
    {
        playerToFollow = player;
        isFollowing = true;
    }
}
