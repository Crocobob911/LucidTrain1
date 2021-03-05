using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DialogueSystem : MonoBehaviour // 대화창 대사를 받아 다음으로 넘기는 역할
{
    public Text txtName;
    public Text txtSentence;

    Queue<string> names = new Queue<string>();
    Queue<string> sentences = new Queue<string>();

    public void DialogueBegin(Dialogue info)
    {
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
        Debug.Log("Dialogue Began");
    }

    public void DialogueNext()
    {
        txtName.text = names.Dequeue();
        txtSentence.text = sentences.Dequeue();

        Debug.Log("Dialogue Touched");
    }

    public void DialogueEnd()
    {
        Debug.Log("Dialogue Ended");
    }
}


[System.Serializable]
public class Dialogue
{
    public List<string> names;
    public List<string> sentences;
}