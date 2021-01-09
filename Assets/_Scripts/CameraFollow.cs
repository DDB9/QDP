using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float CameraDistance = 1.5f;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(player.transform.position.x, player.transform.position.y, CameraDistance);
        Vector3 currentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(currentPos, targetPos, Time.deltaTime * MoveSpeed);
    }
}
