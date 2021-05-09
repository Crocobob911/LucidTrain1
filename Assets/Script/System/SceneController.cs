using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private Vector3 homePosition;
    [SerializeField] private RectTransform rectTransform;

    private void Start()
    {
        homePosition = rectTransform.localPosition;
    }

    public void SetScene()
    {
        rectTransform.localPosition = new Vector3(0, 0, 0);
    }

    public void GetSceneBack()
    {
        rectTransform.localPosition = homePosition;
    }
}