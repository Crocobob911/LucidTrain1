using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public int slotnum;
    public Item item;
    public Image itemIcon;

    [SerializeField] private Image selectedLight;
    private bool isTapping = false;
    private float lastTap;
    private float tapTime = 0.2f;

    public void UpdateSlotUI()
    {
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
    }

    public void RemoveSlot()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isTapping==false && DialogueSystem.instance.isTexting==false)
        {
            StartCoroutine("SingleTouched");
            isTapping = true;
        }

        if ((Time.time - lastTap) < tapTime)
        {
            isTapping = false;
            DoubleTouched();
        }
        lastTap = Time.time;
    }

    public IEnumerator SingleTouched() //원 터치, 사용 준비.
    {
        if (item == null)
            yield return null;

        yield return new WaitForSeconds(tapTime);
        if (isTapping)
        {
            Debug.Log("SingleTap");
            isTapping = false;

            TouchArea.instance.gameObject.SetActive(true);
            TouchArea.instance.delTouched += UnSelected;

            selectedLight.color = new Color(80/255f,80/255f,80/255f,100/255f);

            //Inventory.instance.RemoveItem(slotnum);
        }
        
        //Inventory.instance.RemoveItem(slotnum);
        
        //bool isUse = item.Use();
        //if (isUse)
        //{
        //    Inventory.instance.RemoveItem(slotnum);
        //}
    }

    private void DoubleTouched() //더블터치, 툴팁 창 출력
    {
        ToolTipBox.instance.ToolTipOn(item, gameObject.transform.position);
    }

    public void UnSelected()
    {
        selectedLight.color = new Color(80 / 255f, 80 / 255f, 80 / 255f, 0f);


        TouchArea.instance.InitTouchArea();
    }
}
