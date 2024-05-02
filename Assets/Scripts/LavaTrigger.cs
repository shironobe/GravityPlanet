using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject LavaObj;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySfx(6);
            LavaObj.SetActive(true);
            GameManager.Instance.CameraShake();
        }
    }
}
