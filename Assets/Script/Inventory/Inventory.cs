using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    public List<Item> items = new List<Item>();

    public int slotCnt;

    private void Start()
    {
        slotCnt = 6;
    }

    public bool AddItem(Item _item)
    {
        if(items.Count < slotCnt)
        {
            items.Add(_item);
            if(onChangeItem != null)
            onChangeItem.Invoke();
            return true;
        }
            return false;
    }

    public void RemoveItem(int _index)
    {
        items.RemoveAt(_index);
        onChangeItem.Invoke();
    }

    public void GetInvenItem(int id)
    {
            Debug.Log("Get Item / id = " + id);
            AddItem(ItemDatabase.instance.itemDB[id]);
            //Debug.Log(ItemDatabase.instance.itemDB[id].itemName);
    }
}
