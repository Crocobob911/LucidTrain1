using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemImage;

    public bool itemUse()
    {
        return false;
    }

    public bool Use()
    {
        bool isUsed = false;

        return isUsed;
    }
}


