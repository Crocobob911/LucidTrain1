using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private Scrollbar soundScroll;

    [SerializeField] private DialogueSystem dialSystem;
    [SerializeField] private Scrollbar fontSizeScroll;
    private int fontSize;

    public void SetMusicVolume()
    {
        musicSource.volume = soundScroll.value;
    }

    public void SetFontSize()
    {
        fontSize = (int)(45 + 30 * fontSizeScroll.value);
        dialSystem.txtName.fontSize = fontSize;        
        dialSystem.txtSentence.fontSize = fontSize;
    }
}
