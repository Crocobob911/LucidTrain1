using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    [SerializeField] private int frameCount = 60;

    private void Awake()
    {
        setupFrame();
    }

    private void setupFrame()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = frameCount;

        //Debug.Log("Frame Fixed : " + frameCount);
    }

}
