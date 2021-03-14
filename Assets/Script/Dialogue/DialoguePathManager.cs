using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialoguePathManager : MonoBehaviour
{
    public List<string> DialaoguePath = new List<string>();
    string assetsPath;

    private void Start()
    {
        DialaoguePath.Clear();
        PathFinder();
        Debug.Log(assetsPath);
        PathLoad();
    }

    private void PathLoad()
    {
        DialaoguePath.Add(Path.Combine(assetsPath, "Json/dummyTextData1.json"));
        DialaoguePath.Add(Path.Combine(assetsPath, "Json/dummyTextData2.json"));
    }

    private void PathFinder()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            assetsPath = Application.streamingAssetsPath;
        }
        else
        {
            assetsPath = Application.dataPath;
        }
    }
}
