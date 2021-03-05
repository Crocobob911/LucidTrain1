using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadPrac : MonoBehaviour
{
    private PlayerData data;


    private void Start()
    {
        LoadPlayerDataFromJson();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) //data 를 저장 파일에 쓰기
        {
            SavePlayerDataToJson();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) //저장 파일에서 정보를 불러와  data에 저장
        {
            LoadPlayerDataFromJson();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) //현재 불러와진 data 정보들 출력
        {
            Debug.Log(data.name);
            Debug.Log(data.age);
            Debug.Log(data.isDead);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) //data 정보 임의 변경
        {
            data.age = 24;
            data.isDead = true;
            data.name = "Jackie";
            Debug.Log("Data changed");
        }
    }

    [ContextMenu("To Json Data")]
    void SavePlayerDataToJson() //저장
    {
        string jsonData = JsonUtility.ToJson(data, true);
        string path = Path.Combine(Application.dataPath, "Json/playerData.json");
        File.WriteAllText(path, jsonData);
        Debug.Log("Data Saved");
    }

    [ContextMenu("From Json Data")]
    void LoadPlayerDataFromJson() //불러오기
    {
        string path = Path.Combine(Application.dataPath, "Json/playerData.json");
        string jsonData = File.ReadAllText(path);
        data = JsonUtility.FromJson<PlayerData>(jsonData);
        Debug.Log("Data Loaded");
    }
}


[System.Serializable]
public class PlayerData
{
    public int age;
    public bool isDead;
    public string name;
}
