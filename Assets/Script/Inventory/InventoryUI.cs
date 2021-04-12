using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private Transform slotHolder;

    private Slot[] slots;
    private bool activeInventory = false;


    private void Start()
    {
        slots = slotHolder.GetComponentsInChildren<Slot>();
        Inventory.instance.onChangeItem += RedrawSlotUI;
        SlotNumbering();
        RedrawSlotUI();
        //inventoryPanel.gameObject.GetComponent<RectTransform>().DOLocalMoveY(0f, 0.02f);
        inventoryPanel.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(180f, 0f), 0.02f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SlotOnOff(false);
        }
    }

    public void InvenOnOff()
    {
        //Debug.Log("Inven Button Pushed");
        if (activeInventory)
        {
            //inventoryPanel.gameObject.GetComponent<RectTransform>().DOLocalMoveY(0f, 0.3f);
            inventoryPanel.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(180f, 0f), 0.3f);
        }
        else
        {
            //inventoryPanel.gameObject.GetComponent<RectTransform>().DOLocalMoveY(-933f, 0.3f);
            inventoryPanel.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(180f, 933f), 0.3f);
        }
        activeInventory = !activeInventory;

        /*
        activeInventory = !activeInventory;
        inventoryPanel.SetActive(activeInventory);
        */
    }

    private void SlotNumbering()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].slotnum = i;
        }
    }

    void RedrawSlotUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].gameObject.SetActive(false);
            slots[i].RemoveSlot();
        }
        for (int i = 0; i < Inventory.instance.items.Count; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].item = Inventory.instance.items[i];
            slots[i].UpdateSlotUI();
        }
    }

    public void SlotOnOff(bool onOff)
    {
        if (!onOff)
        {
            for (int i = 2; i < 5; i++)
            {
                slots[i].gameObject.SetActive(false);
            }
        }
    }
}