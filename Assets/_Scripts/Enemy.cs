using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MovementSpeed;

    [HideInInspector]
    public bool Frozen = false;

    // Update is called once per frame
    void Update()
    {
        if (!Frozen) transform.Translate(Vector2.right * Time.deltaTime);
    }
}
