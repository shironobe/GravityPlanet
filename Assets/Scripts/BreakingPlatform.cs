using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sr;

    [SerializeField] Sprite HalfBroken;

    bool ishalfBroken;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (ishalfBroken)
            {
                Destroy(gameObject);

            }
            if (!ishalfBroken)
            {
                ishalfBroken = true;
                sr.sprite = HalfBroken;
            }

           


        }
    }
}
