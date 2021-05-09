using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private List<SceneController> sceneList = new List<SceneController>();

    private int lastSceneIndex;

    private void Start()
    {
        MoveScene(0);
    }

    public void MoveScene(int index)
    {
        #region SceneNumber
        /* 
            0 = 텍스트 화면
            1 = 메뉴 화면
            2 = 환경설정
        */
        #endregion

        sceneList[lastSceneIndex].GetSceneBack();

        lastSceneIndex = index;
        sceneList[lastSceneIndex].SetScene();

    }
}
