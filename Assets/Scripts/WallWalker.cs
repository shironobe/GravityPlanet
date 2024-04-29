using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallWalker : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Transform Pos1, Pos2;
    SpriteRenderer sr;
    void Start()
    {
       // RemoveParent();
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }
    void RemoveParent()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).SetParent(null);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
