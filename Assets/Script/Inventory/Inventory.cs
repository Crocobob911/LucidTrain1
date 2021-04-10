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
        slotCnt = 0;
    }

    public void AddItem(int id) //인벤토리에 아이템 추가
    {
        slotCnt++;
        items.Add(ItemDatabase.instance.itemDB[id]);
        if(onChangeItem != null)
        onChangeItem.Invoke();

        Debug.Log("Get Item - ItemID : " + id);
    }

    public void RemoveItem(int id) //인벤토리에서 아이템 삭제
    {
        items.RemoveAt(id);
        onChangeItem.Invoke();

        Debug.Log("Lose Item - ItemID : " + id);
    }
}
