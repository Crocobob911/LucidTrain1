using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialogueSet : MonoBehaviour // 텍스트 파일들의 경로를 textData에 저장하고
                                         // 저장된 TextData에서 데이터를 들고와 
                                         // 출력할 준비하는 역할
{
    public DialoguePathManager textData;

    private void Start()
    {
        textData = GameObject.Find("DialoguePathManager").GetComponent<DialoguePathManager>();
    }

    public void SetText(int index)
    {
        var system = GameObject.Find("DialogueSystem").GetComponent<DialogueSystem>();

        var data = JsonUtility.FromJson<Dialogue>(File.ReadAllText(textData.DialaoguePath[index]));
        system.DialogueBegin(data);
    }
}
