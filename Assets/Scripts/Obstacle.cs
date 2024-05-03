using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
   


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController.Instance.SpawnPlayerDeathEffect();
            AudioManager.Instance.PlaySfx(5);
           
            GameManager.Instance.Activate_Restart_Panel();
        }   
        

        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            //AudioManager.Instance.PlaySfx(5);
           // other.gameObject.SetActive(false);
           // GameManager.Instance.Activate_Restart_Panel();
        }
    }
}
