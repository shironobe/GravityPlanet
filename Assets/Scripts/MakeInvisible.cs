using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeInvisible : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
