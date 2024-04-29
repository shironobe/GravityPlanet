using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sr;
  public  Sprite checkPointOn, checkPointOff;

    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sr.sprite = checkPointOn;
            setCheckPointPos();
        }
        
    }

    void setCheckPointPos()
    {
        GameManager.Instance.setCheckPoint(transform.position);

    }
}
