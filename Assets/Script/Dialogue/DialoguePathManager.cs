using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialoguePathManager : MonoBehaviour
{
    public List<string> DialaoguePath = new List<string>();

    private void Start()
    {
        DialaoguePath.Clear();
        PathLoad();
    }

    private void PathLoad()
    {
        DialaoguePath.Add(Path.Combine(Application.dataPath, "Json/dummyTextData1.json"));
        DialaoguePath.Add(Path.Combine(Application.dataPath, "Json/dummyTextData2.json"));
    }
}
