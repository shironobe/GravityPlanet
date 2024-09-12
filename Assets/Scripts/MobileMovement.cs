using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject[] MobileButtons;

    private void Start()
    {

        if (Application.isMobilePlatform)
        {
            for (int i = 0; i < MobileButtons.Length; i++)
            {
                MobileButtons[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < MobileButtons.Length; i++)
            {
               MobileButtons[i].SetActive(false); 
            }
        }
        
    }

   
  
  
   
    
    public void MoveRight()
    {
        PlayerController.Instance.RightButton();
    }
    public void MoveRightUp()
    {
        PlayerController.Instance.RightButtonUp();
    }

    public void MoveLeft()
    {
        PlayerController.Instance.LeftButton();
    }
    public void MoveLeftUp()
    {
        PlayerController.Instance.LeftButtonUp();
    }
    public void MoveUp()
    {
        PlayerController.Instance.Jumped();
    }
    public void MoveUpUp()
    {
        PlayerController.Instance.JumpedUp();
    }
    public void Exit()
    {
        GameManager.Instance.LodMainMenu();
    }
    public void Restart()
    {
        GameManager.Instance.RestartScene();
    }

}
