using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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

    [SerializeField] private Text tooltipName;
    [SerializeField] private Text tooltipExplain;

    [SerializeField] private GameObject closeArea;

    private void Start()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
        gameObject.transform.DOScale(new Vector3(0, 0, 0), 0.2f);
        closeArea.SetActive(false);
    }

    public bool ToolTipOn(Item _item, Vector3 _pos)
    {
        gameObject.transform.position = _pos;
        Vector3 pos = new Vector3(_pos.x - 430f, _pos.y - 50f, _pos.z);

        gameObject.SetActive(true);
        closeArea.SetActive(true);
        gameObject.transform.DOMove(pos, 0.2f);
        gameObject.transform.DOScale(new Vector3(1,1,0), 0.2f);
        tooltipName.text = _item.itemName;
        tooltipExplain.text = _item.itemTooltip;


        //gameObject.transform.position= pos;
        return true;
    }

    public void ToolTipOff()
    {
        Vector3 pos = new Vector3(transform.position.x + 430f, transform.position.y + 50f, transform.position.z);
        gameObject.transform.DOMove(pos, 0.2f);
        gameObject.transform.DOScale(new Vector3(0, 0, 0), 0.2f);
        closeArea.SetActive(false);
    }
}
