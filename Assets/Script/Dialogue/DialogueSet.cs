using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialogueSet : MonoBehaviour // 텍스트 파일들의 경로를 textData에 저장하고
                                         // 저장된 TextData에서 데이터를 들고와 
                                         // 출력할 준비하는 역할
{
    public DialoguePathManager pathManager;

    private DialogueSystem dialSystem;
    private TextAsset textAsset;

    private void Start()
    {
        dialSystem =  GameObject.Find("DialogueSystem").GetComponent<DialogueSystem>();
    }

    public void SetText(int index)
    {
        textAsset = Resources.Load(pathManager.DialoguePath[index]) as TextAsset;
        var data = JsonUtility.FromJson<Dialogue>(textAsset.ToString());
        dialSystem.DialogueBegin(data);
    }
}
