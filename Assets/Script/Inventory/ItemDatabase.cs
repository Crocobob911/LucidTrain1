using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    private void Awake()
    {
        instance = this;
    }

    public List<Item> itemDB = new List<Item>();

}

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemImage;
    public string itemTooltip;


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