using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadPrac : MonoBehaviour
{
    public PlayerData data;

    private string assetPath;

    private void Awake()
    { 
        PathFinder();
    }

    private void Update()
    {
        /*
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
        */
    }

    public void SavePlayerDataToJson() //저장
    {

        //data.invenData = Inventory.instance.items;
        string jsonData = JsonUtility.ToJson(data, true);
        File.WriteAllText(assetPath + "/Saves/playerData.json", jsonData);

        Debug.Log("Data Saved");
    }

    public void LoadPlayerDataFromJson() //불러오기
    {
        string jsonData = File.ReadAllText(assetPath + "/Saves/playerData.json");
        data = JsonUtility.FromJson<PlayerData>(jsonData);
        Debug.Log("Data Loaded");
        Debug.Log(JsonUtility.FromJson<PlayerData>(jsonData).age);
        Debug.Log(JsonUtility.FromJson<PlayerData>(jsonData).isDead);
        Debug.Log(JsonUtility.FromJson<PlayerData>(jsonData).name);
    }

    public void saveloadtestone()
    {
        data.age = 24;
        data.isDead = true;
        data.name = "Jackie";
        Debug.Log("Data changed");
    }
    public void saveloadtesttwo()
    {
        data.age = 16;
        data.isDead = false;
        data.name = "Sissela";
        Debug.Log("Data changed");
    }

    private void PathFinder()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            assetPath = Application.persistentDataPath;
            if (!Directory.Exists(Application.persistentDataPath + "/Saves"))
                Directory.CreateDirectory(Application.persistentDataPath + "/Saves");

            Debug.Log("Platform : Android");
        }
        else
        {
            assetPath = Application.dataPath +"/Resources";
            Debug.Log("Platform : Unity Editor");
        }
    }
}



[System.Serializable]
public class PlayerData
{
    public int age;
    public bool isDead;
    public string name;
    //public List<Item> invenData = new List<Item>();
}
