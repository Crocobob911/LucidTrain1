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
        inventoryPanel.gameObject.transform.DOScaleY(0, 0.02f);
        //inventoryPanel.SetActive(false);
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
            inventoryPanel.gameObject.transform.DOScaleY(0, 0.3f);
        }
        else
        {
            inventoryPanel.gameObject.transform.DOScaleY(1, 0.3f);
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