using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void Awake()
    {
        setupCamera();
    }
    private void setupCamera()
    {
        float targetWidthAspect = 16.0f;
        float targetHeightAspect = 9.0f;

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
    }
}
