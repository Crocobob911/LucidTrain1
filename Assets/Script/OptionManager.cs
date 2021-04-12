using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private Scrollbar volumeBar;

    [SerializeField] private DialogueSystem dialSystem;
    [SerializeField] private Scrollbar fontSizeBar;
    private int fontSize;

    public void SetMusicVolume()
    {
        musicSource.volume = volumeBar.value;
    }

    public void SetFontSize()
    {
        fontSize = (int)(45 + 30 * fontSizeBar.value);
        dialSystem.txtName.fontSize = fontSize;        
        dialSystem.txtSentence.fontSize = fontSize;
    }
}
