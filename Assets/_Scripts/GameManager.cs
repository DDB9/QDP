using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    public GameObject Player;
    public GameObject World;
    public GameObject Hell;
    public GameObject HellWorldComponent;
    public GameObject CurrentCheckpoint;
    public GameObject GameOverScreen;
    public GameObject GameWinScreen;
    public GameObject BustedScreen;
    public Transform Spawnpoint;
    public Transform KopterSpawn;
    public Transform HellEntrance;
    public List<Enemy> Enemies = new List<Enemy>();
    public List<Checkpoint> Checkpoints = new List<Checkpoint>();
    public List<GameObject> FeintWalls = new List<GameObject>();

    private bool startGame = false;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (GameOverScreen.activeSelf || BustedScreen.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R)) Restart();
        }
        else if (GameWinScreen.activeSelf)
        {
            if (Input.anyKey) Application.Quit();
        }

        if (startGame) StartGame();
    }

    private void Restart()
    {
        if (CurrentCheckpoint != null)
        {
            foreach (Checkpoint point in Checkpoints)
            {
                if (point != CurrentCheckpoint)
                {
                    point.transform.parent = HellWorldComponent.transform;
                }
            }
            CurrentCheckpoint.transform.position = HellEntrance.position;
        }

        World.GetComponent<Animator>().Play("WorldRotationReset");

        Player.transform.position = Spawnpoint.position;
        Player.transform.rotation = Quaternion.Euler(Vector3.zero);
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        Player.GetComponent<PlayerMovement>().enabled = true;

        Camera.main.transform.position = new Vector3(Spawnpoint.position.x,
                                                     Spawnpoint.position.y,
                                                     Camera.main.GetComponent<CameraFollow>().CameraDistance);
        foreach (Enemy enemy in Enemies)
        {
            enemy.transform.position = KopterSpawn.position;
            enemy.Frozen = true;
        }

        GameOverScreen.SetActive(false);
        BustedScreen.SetActive(false);
        startGame = true;
    }
    
    private void StartGame()
    {
        foreach (Enemy enemy in Enemies)
            enemy.Frozen = false;

        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        foreach (Checkpoint point in Checkpoints)
        {
                point.transform.parent = Hell.transform;
        }
        foreach (GameObject wall in FeintWalls)
        {
            wall.SetActive(true);
        }

        startGame = false;
    }
}
