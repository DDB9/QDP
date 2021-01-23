using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.GetComponent<Player>())
        {
            if (transform.CompareTag("Kopterlicht"))
            {
                GameManager.Instance.BustedScreen.SetActive(true);
            }
            other.transform.GetComponent<Rigidbody2D>().AddTorque(-1f);
            Debug.Log("You died! But your mission is not yet over...");
            other.transform.GetComponent<Rigidbody2D>().freezeRotation = false;
            other.transform.GetComponent<PlayerMovement>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        foreach (Enemy enemy in GameManager.Instance.Enemies)
        {
            enemy.Frozen = true;
        }

        if (collision.transform.GetComponent<Player>() && CompareTag("Overworld"))
        {
            GameManager.Instance.World.GetComponent<Animator>().Play("WorldDeathRotation");
            GameManager.Instance.Hell.SetActive(true);
        }

        if (collision.transform.GetComponent<Player>() && CompareTag("Hell"))
        {
            GameManager.Instance.GameOverScreen.SetActive(true);
        }
    }
}
