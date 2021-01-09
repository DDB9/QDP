using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public List<Enemy> Enemies = new List<Enemy>();

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
