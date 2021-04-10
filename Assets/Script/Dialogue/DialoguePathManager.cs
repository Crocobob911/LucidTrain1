using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialoguePathManager : MonoBehaviour
{
    // *******************안 쓰는 파일*********************
    
    public List<string> DialoguePath = new List<string>();
    string assetsPath;

    private void Start()
    {
        DialoguePath.Clear();
        PathFinder();
        Debug.Log(assetsPath);
        PathLoad();
    }

    private void PathLoad()
    {
        DialoguePath.Add("Json/dummyTextData1");
        DialoguePath.Add("Json/dummyTextData2");
        /*
        DialaoguePath.Add(Path.Combine(assetsPath, "Json/dummyTextData1.json"));
        DialaoguePath.Add(Path.Combine(assetsPath, "Json/dummyTextData2.json"));
        */
    }

    private void PathFinder()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            assetsPath = Application.persistentDataPath;
        }
        else
        {
            assetsPath = Application.dataPath;
        }
    }
}
