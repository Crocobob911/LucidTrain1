using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDB : MonoBehaviour
{
    #region SingletonAndAwake
    public static DialogueDB instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        GetDialDatabase();

    }
    #endregion

    [SerializeField] private List<Dialogue> dialSheetList;
    private int sheetListLength;

    public List<DialogueForm> dialDB;
    private int dialDBLength; 


    private void GetDialDatabase()
    {
        sheetListLength = dialSheetList.Count;
        //Debug.Log("sheetListLength = " + sheetListLength);

        for (int i = 0; i < sheetListLength; i++)
        {
            dialDBLength = dialSheetList[i].dataArray.Length;
            //Debug.Log("dialDBtLength = " + dialDBLength);
            for (int j = 0; j < dialDBLength; j++)
            {
                dialDB[i].keys.Add(dialSheetList[i].dataArray[j].Key);
                dialDB[i].names.Add(dialSheetList[i].dataArray[j].Name);
                dialDB[i].sentences.Add(dialSheetList[i].dataArray[j].Sentence);
            }
        }
    }
}
