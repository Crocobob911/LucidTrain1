using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchArea : MonoBehaviour
{
    #region Singleton
    public static TouchArea instance;
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

    public delegate void DelTouched();
    public DelTouched delTouched = null;

    public void Start()
    {
        InitTouchArea();
    }

    public void AreaTouched()
    {
        delTouched();
    }

    public void InitTouchArea()
    {
        delTouched = null;
        gameObject.SetActive(false);
    }
}
