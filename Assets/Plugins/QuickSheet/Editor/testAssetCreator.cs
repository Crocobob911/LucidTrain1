using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/test")]
    public static void CreatetestAssetFile()
    {
        test asset = CustomAssetUtility.CreateAsset<test>();
        asset.SheetName = "LucidTrain";
        asset.WorksheetName = "test";
        EditorUtility.SetDirty(asset);        
    }
    
}