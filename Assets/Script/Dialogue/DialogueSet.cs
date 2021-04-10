using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialogueSet : MonoBehaviour
{
    private DialogueSystem dialSystem;
    private DialogueDB dialDB;

    /*
    public DialoguePathManager pathManager;
    private TextAsset textAsset;
    */

    private void Start()
    {
        dialSystem =  GameObject.Find("DialogueSystem").GetComponent<DialogueSystem>();
        dialDB = GameObject.Find("DialogueDatabase").GetComponent<DialogueDB>();
    }

    public void SetText(int index)
    {
        dialSystem.DialogueBegin(dialDB.dialDB[index]);

        Debug.Log("Dialogue set - dial " + index);

        /*
        textAsset = Resources.Load(pathManager.DialoguePath[index]) as TextAsset;
        var data = JsonUtility.FromJson<DialogueForm>(textAsset.ToString());
        dialSystem.DialogueBegin(data);
        */
    }
}
