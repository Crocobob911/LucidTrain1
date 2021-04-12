using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ToolTipBox : MonoBehaviour
//다음 텍스트로 넘어갈 때,
//툴팁창을 닫을 때, 활용할 모든 UI 앞에 있는 빈 화면
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

    private Vector3 movePos;

    private void Start()
    {
        OffToolTip();
    }

    public void OnToolTip(Item _item, Vector3 _pos)
    {
        gameObject.transform.position = _pos;
        movePos = new Vector3(_pos.x -160f, _pos.y - 30f, _pos.z);

        gameObject.SetActive(true);
        TouchArea.instance.gameObject.SetActive(true);
        TouchArea.instance.delTouched += OffToolTip;

        gameObject.transform.DOMove(movePos, 0.2f);
        gameObject.transform.DOScale(new Vector3(1,1,0), 0.2f);
        tooltipName.text = _item.name;
        tooltipExplain.text = _item.tooltip;


        //gameObject.transform.position= pos;
    }

    public void OffToolTip()
    {
        movePos = new Vector3(transform.position.x + 160f, transform.position.y + 30f, transform.position.z);
        gameObject.transform.DOMove(movePos, 0.2f);
        gameObject.transform.DOScale(new Vector3(0, 0, 0), 0.2f);

        TouchArea.instance.InitTouchArea();
    }
}
