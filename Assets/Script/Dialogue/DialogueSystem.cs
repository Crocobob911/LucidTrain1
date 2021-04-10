using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DialogueSystem : MonoBehaviour // 대화창 대사를 받아 다음으로 넘기는 역할
{

    public Text txtName;
    public Text txtSentence;

    //[SerializeField] private GameObject nameText;
    //[SerializeField] private GameObject sentenceText;
    [SerializeField] private GameObject textBar;
    [SerializeField] private GameObject touchArea;

    Queue<string> names = new Queue<string>();
    Queue<string> sentences = new Queue<string>();
    List<int> itemIDs = new List<int>(); 

    private void Start()
    {
        textBar.SetActive(false);
        touchArea.SetActive(false);
    }

    public void DialogueBegin(DialogueForm info) //대화창 on 및 첫 문장 출력
    {

        textBar.SetActive(true);
        touchArea.SetActive(true);

        names.Clear();
        sentences.Clear();
        itemIDs.Clear();

        foreach (var name in info.names)
        {
            names.Enqueue(name);
        }
        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach(var num in info.clueIDs)
        {
            itemIDs.Add(num);
        }

        DialogueNext();
    }

    public void DialogueNext() //TouchArea 터치하면 다음 대사 출력
    {
        if (names.Count == 0)
        {
            DialogueEnd();
        }
        else
        {
            txtName.text = names.Dequeue();
            txtSentence.text = sentences.Dequeue();
        }
    }

    public void DialogueEnd() //마지막 대사 출력 이후 처리
    {
        txtName.text = " ";
        txtSentence.text = " ";
        
        foreach(var itemid in itemIDs)
        {
            Inventory.instance.AddItem(itemid);
        }

        textBar.SetActive(false);
        touchArea.SetActive(false);
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