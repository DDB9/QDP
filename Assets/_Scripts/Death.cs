using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.GetComponent<Player>())
        {
            other.transform.GetComponent<Rigidbody2D>().AddTorque(-1f);
            Debug.Log("You died! But your mission is not yet over...");
            other.transform.GetComponent<Rigidbody2D>().freezeRotation = false;
            other.transform.GetComponent<PlayerMovement>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Player>())
        {
            collision.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            foreach (Enemy enemy in GameManager.Instance.Enemies)
            {
                enemy.Frozen = true;
            }

            GameManager.Instance.World.GetComponent<Animator>().Play("WorldDeathRotation");
            GameManager.Instance.Hell.SetActive(true);
        }
    }
}
