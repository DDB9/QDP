using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableControls : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Player>())
        {
            collision.transform.GetComponent<PlayerMovement>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.CompareTag("FakeHole"))
        {
            gameObject.SetActive(false);
        }
    }
}
