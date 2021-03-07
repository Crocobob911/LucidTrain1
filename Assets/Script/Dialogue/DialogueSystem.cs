using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DialogueSystem : MonoBehaviour // 대화창 대사를 받아 다음으로 넘기는 역할
{
    public Text txtName;
    public Text txtSentence;

    private GameObject textBar;
    private GameObject touchArea;

    Queue<string> names = new Queue<string>();
    Queue<string> sentences = new Queue<string>();

    private void Start()
    {
        textBar = GameObject.Find("TextBar");
        touchArea = GameObject.Find("TouchArea");

        textBar.SetActive(false);
        touchArea.SetActive(false);
    }

    public void DialogueBegin(Dialogue info)
    {

        textBar.SetActive(true);
        touchArea.SetActive(true);

        names.Clear();
        sentences.Clear();

        foreach (var name in info.names)
        {
            names.Enqueue(name);
        }
        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DialogueNext();

        Debug.Log("Dialogue Began");
    }

    public void DialogueNext()
    {
        if(names.Count == 0)
        {
            DialogueEnd();
        }
        else
        {
            txtName.text = names.Dequeue();
            txtSentence.text = sentences.Dequeue();
        }

        Debug.Log("Dialogue Touched");
    }

    public void DialogueEnd()
    {
        txtName.text = " ";
        txtSentence.text = " ";

        textBar.SetActive(false);
        touchArea.SetActive(false);
        Debug.Log("Dialogue Ended");
    }
}


[System.Serializable]
public class Dialogue
{
    public List<string> names;
    public List<string> sentences;
}