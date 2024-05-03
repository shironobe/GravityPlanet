using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;

    public Vector2 LastCheckPointPos;

    public Transform Player;

    public GameObject RestartPanel;

   [SerializeField]  CinemachineVirtualCamera vcam;
   [SerializeField]  CinemachineBasicMultiChannelPerlin noise;

   [SerializeField] GameObject Levels;

    [SerializeField] Animator fadeAnim;

    [SerializeField] GameObject CompletedGamePanel;

   
    
    private void Awake()
    {
        if (Instance != null)
        {
           // Destroy(gameObject);
        }
        else
        {
            Instance = this;

            //DontDestroyOnLoad(gameObject);

        }
    }
    void Start()
    {
         // vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera> ();
        noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin> ();
        //  RestartPanel = GameObject.FindGameObjectWithTag("RestartPanel").gameObject;

      //  Player = GameObject.FindGameObjectWithTag("Player").transform;


      // LastCheckPointPos = Player.position;

        if (AudioManager.Instance.ShouldRespawn)
        {
           // PlayerPrefs.SetFloat("PosX", LastCheckPointPos.x);

           // PlayerPrefs.SetFloat("PosY", LastCheckPointPos.y);
        }
        AudioManager.Instance.ShouldRespawn = true;


    }

  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LodMainMenu();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {


            RestartScene();


        }

    
    }

    void Respawn()
    {
        LastCheckPointPos = new Vector2(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"));

        Physics2D.gravity = new Vector2(0, -9.81f);
        PlayerController.Instance.transform.position = LastCheckPointPos;
        PlayerController.Instance.ResetPlayer();
    }



    IEnumerator RestartLevelCo()
    {
        fadeAnim.SetTrigger("end");
        yield return new WaitForSeconds(1f);

        AudioManager.Instance.ShouldRespawn = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void RestartScene()
    {


        StartCoroutine(RestartLevelCo());
    }

    public void RespawnPlayer()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // LastCheckPointPos = new Vector2(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"));


        // Player = GameObject.FindGameObjectWithTag("Player").transform;
       // Player.position = LastCheckPointPos;
        PlayerController.Instance.transform.position = LastCheckPointPos;
       
        Physics2D.gravity = new Vector2(0, -9.81f);
       
        PlayerController.Instance.ResetPlayer();

        PlayerController.Instance.isDead = false;

        RestartPanel.SetActive(false);
    }
    

    public void Activate_Restart_Panel()
    {
        PlayerController.Instance.isDead = true;
        PlayerController.Instance.gameObject.SetActive(false);
        RestartPanel.SetActive(true);
    }
    public void setCheckPoint(Vector2 pos)
    {
        LastCheckPointPos = pos;
        PlayerPrefs.SetInt("HasCheckpoint", 1);
        PlayerPrefs.SetFloat("PosX", LastCheckPointPos.x);

        PlayerPrefs.SetFloat("PosY", LastCheckPointPos.y);

    }


    public void CameraShake() 
    {
        StartCoroutine(_ProcessShake());
    
    }
    private IEnumerator _ProcessShake(float shakeIntensity = 5f, float shakeTiming = 2f)
    {
        Noise(1, shakeIntensity);
        yield return new WaitForSeconds(shakeTiming);
        Noise(0, 0);
    }

    public void Noise(float amplitudeGain, float frequencyGain)
    {
        noise.m_AmplitudeGain = amplitudeGain;
       // noise.middleRig.Noise.m_AmplitudeGain = amplitudeGain;
       // cmFreeCam.bottomRig.Noise.m_AmplitudeGain = amplitudeGain;

        noise.m_FrequencyGain = frequencyGain;
      //  cmFreeCam.middleRig.Noise.m_FrequencyGain = frequencyGain;
      //  cmFreeCam.bottomRig.Noise.m_FrequencyGain = frequencyGain;

    }

    public void CompletedGame()
    {
        CompletedGamePanel.SetActive(true);

        AudioManager.Instance.PlaySfx(9);
        PlayerController.Instance.isDead = true;
        PlayerController.Instance.stopMoving();
      
        PlayerController.Instance.FreezeRb();
    }

    public void LodMainMenu()
    {
       StartCoroutine(LoadScene(0));
    }


    IEnumerator LoadScene(int SceneNo)
    {
        AudioManager.Instance.PlaySfx(8);
        fadeAnim.SetTrigger("end");
        // AudioManager.instance.PlaySfx(5);
        yield return new WaitForSeconds(0.2f);
        AudioManager.Instance.PlayMusic(0);
        SceneManager.LoadSceneAsync(SceneNo);
    }

}
