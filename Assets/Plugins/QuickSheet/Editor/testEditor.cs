using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using GDataDB;
using GDataDB.Linq;

using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(test))]
public class testEditor : BaseGoogleEditor<test>
{	    
    public override bool Load()
    {        
        test targetData = target as test;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<testData>(targetData.WorksheetName) ?? db.CreateTable<testData>(targetData.WorksheetName);
        
        List<testData> myDataList = new List<testData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            testData data = new testData();
            
            data = Cloner.DeepCopy<testData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
