using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public int slotNum;
    public Item item;
    public Image itemIcon;

    [SerializeField] private Image selectedLight;
    private bool isTapping = false;
    private float lastTapTime;
    private float tapTimeTerm = 0.2f;

    public void UpdateSlotUI()
    {
        itemIcon.sprite = item.image;
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

        if ((Time.time - lastTapTime) < tapTimeTerm)
        {
            isTapping = false;
            DoubleTouched();
        }
        lastTapTime = Time.time;
    }

    public IEnumerator SingleTouched() //원 터치, 사용 준비
    {
        if (item == null)
            yield return null;

        yield return new WaitForSeconds(tapTimeTerm);
        if (isTapping)
        {
            isTapping = false;

            TouchArea.instance.gameObject.SetActive(true);
            TouchArea.instance.delTouched += UnSelected;

            selectedLight.color = new Color(80/255f,80/255f,80/255f,100/255f);
        }        
        //bool isUse = item.Use();
        //if (isUse)
        //{
        //    Inventory.instance.RemoveItem(slotnum);
        //}
    }

    private void DoubleTouched() //더블터치, 툴팁 창 출력
    {
        ToolTipBox.instance.OnToolTip(item, gameObject.transform.position);
    }

    public void UnSelected()
    {
        selectedLight.color = new Color(80 / 255f, 80 / 255f, 80 / 255f, 0f);


        TouchArea.instance.InitTouchArea();
    }
}
