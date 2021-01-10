using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CurrentCheckpoint = gameObject;
            GameManager.Instance.HellWorldComponent.transform.parent = gameObject.transform;

            if (transform.parent == GameManager.Instance.HellWorldComponent)
            {
                foreach (Checkpoint point in GameManager.Instance.Checkpoints)
                {
                    if (point != this)
                    {
                        point.transform.parent = GameManager.Instance.HellWorldComponent.transform;
                    }
                }
                transform.parent = GameManager.Instance.Hell.transform;
            }
        }
    }
}
