using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void Awake()
    {
        setupCamera();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
        }
    }

    private void Start()
    {
        MoveCam(1);
    }
    private void setupCamera()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        float targetWidthAspect = 18f;
        float targetHeightAspect = 9f;

        Camera mainCamera = Camera.main;

        mainCamera.aspect = targetWidthAspect / targetHeightAspect;

        float widthRatio = (float)Screen.width / targetWidthAspect;
        float heightRatio = (float)Screen.height / targetHeightAspect;

        float heightadd = ((widthRatio / (heightRatio / 100)) - 100) / 200;
        float widthadd = ((heightRatio / (widthRatio / 100)) - 100) / 200;

        if (heightRatio > widthRatio)
            widthadd = 0.0f;
        else
            heightadd = 0.0f;

        mainCamera.rect = new Rect(
            mainCamera.rect.x + Mathf.Abs(widthadd),
            mainCamera.rect.y + Mathf.Abs(heightadd),
            mainCamera.rect.width + (widthadd * 2),
            mainCamera.rect.height + (heightadd * 2));

        Debug.Log("Screen Fixed : " + targetWidthAspect + " : " + targetHeightAspect);
    }

    public void MoveCam(int index)
    {
        /* 
            1 = 텍스트 화면
            2 = 메뉴 화면
            3 = 환경설정
        */

        switch (index)
        {
            case 1: //텍스트 화면
                gameObject.transform.position = new Vector3(385, 192, -10);
                break;

            case 2: //메뉴 화면
                gameObject.transform.position = new Vector3(1380, 192, -10);
                break;

            case 3: //환경설정
                gameObject.transform.position = new Vector3(2375, 192, -10);
                break;

            default:
                break;
        }

    }
}
