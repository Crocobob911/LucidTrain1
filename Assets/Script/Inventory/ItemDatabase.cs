using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    #region Singleton
    public static ItemDatabase instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public List<Item> itemDB = new List<Item>();

}

[System.Serializable]
public class Item
{
    public string name;
    public Sprite image;
    public string tooltip;


    public bool Use()
    {
        bool isUsed = false;
        /*
        bool isUsed = false;
        foreach (ItemEffect eft in efts)
        {
            isUsed = eft.ExecuteRole();
        }*/

        return isUsed;
    }
}