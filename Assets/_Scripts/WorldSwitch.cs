using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WorldSwitchKey"))
        {
            GameManager.Instance.Player.transform.rotation = Quaternion.Euler(Vector3.zero);
            GameManager.Instance.Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            Camera.main.GetComponent<Animator>().Play("SkyboxToHell");
        }
    }
}
