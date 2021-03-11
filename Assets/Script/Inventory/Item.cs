using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemImage;


    public bool Use()
    {
        bool isUsed = true;
        /*
        bool isUsed = false;
        foreach (ItemEffect eft in efts)
        {
            isUsed = eft.ExecuteRole();
        }*/

        return isUsed;
    }
}


