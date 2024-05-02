using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int Level;

    [SerializeField] int Creditsno;

    [SerializeField] Animator SceneTransition;
    public GameObject ContinueButton;

    public GameObject NewGamePanel;

    public GameObject CreditsPanel;
    void Start()
    {
        if(PlayerPrefs.GetInt("HasCheckpoint") == 1)
        {
            ContinueButton.SetActive(true);
        }
        else
        {
            ContinueButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Continue()
    {

        StartCoroutine(LoadScene(Level));
    }


    public void PlayGame()
    {
        // SceneManager.LoadScene(Level);
       
        if (PlayerPrefs.GetInt("HasCheckpoint") == 1)
        {
            OpenNewGamePanel();
        }
        else
        {
            StartCoroutine(LoadScene(Level));
        }
    }

    public void StartNewGame()
    {
        PlayerPrefs.DeleteKey("HasCheckpoint");
        PlayerPrefs.DeleteKey("PosX");
        PlayerPrefs.DeleteKey("PosY");
        StartCoroutine(LoadScene(Level));
    }

    public void OpenNewGamePanel()
    {
        if (!NewGamePanel.activeSelf)
        {
            NewGamePanel.SetActive(true);
        }
        else
        {
            NewGamePanel.SetActive(false);
        }
    }

    public void Open_Close_CreditsPanel()
    {
        if (!CreditsPanel.activeSelf)
        {
            CreditsPanel.SetActive(true);
        }
        else
        {
            CreditsPanel.SetActive(false);
        }
    }


    //public void Credits()
    //{
    //   // SceneManager.LoadScene(Creditsno);

    //    StartCoroutine(LoadScene(Creditsno));
    //}


    IEnumerator LoadScene(int SceneNo)
    {
        AudioManager.Instance.PlaySfx(8);
        SceneTransition.SetTrigger("end");
      //  AudioManager.instance.PlaySfx(5);
        yield return new WaitForSeconds(0.5f);
        AudioManager.Instance.PlayMusic(1);
        SceneManager.LoadSceneAsync(SceneNo);
    }
}
