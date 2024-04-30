using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;

    public Vector2 LastCheckPointPos;

    public Transform Player;



    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);

        }
    }
    void Start()
    {
      
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        LastCheckPointPos = Player.position;
        PlayerPrefs.SetFloat("PosX", LastCheckPointPos.x);

        PlayerPrefs.SetFloat("PosY", LastCheckPointPos.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {


            ReStartPlayer();


        }
    }
    public void ReStartPlayer()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         LastCheckPointPos = new Vector2(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"));


        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Player.position = LastCheckPointPos;
        Physics2D.gravity = new Vector2(0, -9.81f);

        PlayerController.Instance.ResetPlayer();
    }

    public void RespawnPlayer()
    {
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // LastCheckPointPos = new Vector2(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"));


        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Player.position = LastCheckPointPos;
        Physics2D.gravity = new Vector2(0, -9.81f);
       
        PlayerController.Instance.ResetPlayer();
    }
    


    public void setCheckPoint(Vector2 pos)
    {
        LastCheckPointPos = pos;
        PlayerPrefs.SetFloat("PosX", LastCheckPointPos.x);

        PlayerPrefs.SetFloat("PosY", LastCheckPointPos.y);

    }
}
