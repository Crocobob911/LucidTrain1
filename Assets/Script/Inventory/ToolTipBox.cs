using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipBox : MonoBehaviour
{
    #region Singleton
    public static ToolTipBox instance;
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

    public Text tooltipName;
    public Text tooltipExplain;

    public GameObject closeArea;

    private void Start()
    {
        ToolTipOff();
    }

    public bool ToolTipOn(Item _item, Vector3 _pos)
    {
        Vector3 pos = new Vector3(_pos.x - 430f, _pos.y - 50f, _pos.z);

        gameObject.SetActive(true);
        closeArea.SetActive(true);
        gameObject.transform.position= pos;
        tooltipName.text = _item.itemName;
        tooltipExplain.text = _item.itemTooltip;
        return true;
    }

    public void ToolTipOff()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        gameObject.SetActive(false);
        closeArea.SetActive(false);
    }
}
