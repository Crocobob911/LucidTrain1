using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DialogueSystem : MonoBehaviour // 대화창 대사를 받아 다음으로 넘기는 역할
{
    #region Singleton
    public static DialogueSystem instance;
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

    public Text txtName;
    public Text txtSentence;
    [SerializeField] private GameObject textBar;

    public bool isTexting = false;

    private DialogueForm dialData;
    private Queue<string> nameQueue = new Queue<string>();
    private Queue<string> sentenceQueue = new Queue<string>();
    private List<int> itemIDQueue = new List<int>(); 

    private void Start()
    {
        textBar.SetActive(false);
    }


    public void BeginDialogue(int index) //대화창 on 및 첫 문장 출력
    {
        dialData = DialogueDB.instance.dialDB[index];

        isTexting = true;
        textBar.SetActive(true);

        nameQueue.Clear();
        sentenceQueue.Clear();
        itemIDQueue.Clear();

        foreach (var name in dialData.names)
        {
            nameQueue.Enqueue(name);
        }
        foreach (var sentence in dialData.sentences)
        {
            sentenceQueue.Enqueue(sentence);
        }
        foreach(var num in dialData.clueIDs)
        {
            itemIDQueue.Add(num);
        }

        TouchArea.instance.gameObject.SetActive(true);
        TouchArea.instance.delTouched += NextDialogue;
        NextDialogue();
    }

    public void NextDialogue() //TouchArea 터치하면 다음 대사 출력
    {
        if (nameQueue.Count == 0)
        {
            EndDialogue();
        }
        else
        {
            txtName.text = nameQueue.Dequeue();
            txtSentence.text = sentenceQueue.Dequeue();
        }
    }

    private void EndDialogue() //마지막 대사 출력 이후 처리
    {
        txtName.text = " ";
        txtSentence.text = " ";
        
        foreach(var itemid in itemIDQueue)
        {
            Inventory.instance.AddItem(itemid);
        }

        textBar.SetActive(false);
        TouchArea.instance.InitTouchArea();
        isTexting = false;
    }
}


[System.Serializable]
public class DialogueForm
{
    public List<int> keys;
    public List<string> names;
    public List<string> sentences;

    public List<int> clueIDs;
}