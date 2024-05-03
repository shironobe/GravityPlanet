using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using Cinemachine;
using TMPro;
public class CameraController : MonoBehaviour
{
   // public PixelPerfectCamera PixelCamera;

    bool cameraSet;

    [SerializeField] CinemachineVirtualCamera cm;

  //  [SerializeField] TextMeshProUGUI text;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
       if (!cameraSet)
        {
            if (Screen.width > 900)
            {
                cm.m_Lens.OrthographicSize = 5.98f;                       //laptop
               // PixelCamera.assetsPPU = 22;
                cameraSet = true;
            }
            else
            {
                // PixelCamera.assetsPPU = 26;
                cm.m_Lens.OrthographicSize = 7.98f;
                cameraSet = true;
            }
        }
    }
}
