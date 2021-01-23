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
    public GameObject CountdownScreen;
    public TextMeshProUGUI CountdownText;
    public Transform Spawnpoint;
    public Transform KopterSpawn;
    public Transform HellEntrance;
    public List<Enemy> Enemies = new List<Enemy>();
    public List<Checkpoint> Checkpoints = new List<Checkpoint>();

    private float startTimer = 3f;
    private bool startGame = false;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (GameOverScreen.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R)) Restart();
        }
        if (startGame) StartGame();
    }

    private void Restart()
    {
        foreach (Checkpoint point in Checkpoints)
        {
            if (point != CurrentCheckpoint)
            {
                point.transform.parent = HellWorldComponent.transform;
            }
        }
        CurrentCheckpoint.transform.position = HellEntrance.position;

        World.GetComponent<Animator>().Play("WorldRotationReset");
        Player.transform.position = Spawnpoint.position;
        Camera.main.transform.position = new Vector3(Spawnpoint.position.x,
                                                     Spawnpoint.position.y,
                                                     Camera.main.GetComponent<CameraFollow>().CameraDistance);
        foreach (Enemy enemy in Enemies)
        {
            enemy.transform.position = KopterSpawn.position;
        }

        GameOverScreen.SetActive(false);
        startGame = true;
    }
    
    private void StartGame()
    {
        CountdownScreen.SetActive(true);
        CountdownText.SetText(startTimer.ToString("f0"));
        startTimer -= Time.deltaTime;
        if (startTimer <= 0)
        {
            foreach (Enemy enemy in Enemies)
                enemy.Frozen = false;

            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            foreach (Checkpoint point in Checkpoints)
            {
                 point.transform.parent = Hell.transform;
            }

            startTimer = 3f;
            CountdownScreen.SetActive(false);
            startGame = false;
        }
    }
}
