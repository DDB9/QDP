using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Player PlayerObject;
    public float RunSpeed = 40f;

    private float horizontalMovement = 0f;
    private bool jump = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * RunSpeed;

        if (Input.GetButtonDown("Jump")) jump = true;
    }

    private void FixedUpdate()
    {
        PlayerObject.Move(horizontalMovement * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
