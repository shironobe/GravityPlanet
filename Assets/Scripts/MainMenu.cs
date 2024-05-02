using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int Level;

    [SerializeField] int Creditsno;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void PlayGame()
    {
        SceneManager.LoadScene(Level);
    }

    public void Credits()
    {
        SceneManager.LoadScene(Creditsno);
    }
}
