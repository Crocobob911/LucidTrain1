using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
///
[System.Serializable]
public class DialogueData
{
  [SerializeField]
  int key;
  public int Key { get {return key; } set { this.key = value;} }
  
  [SerializeField]
  string name;
  public string Name { get {return name; } set { this.name = value;} }
  
  [SerializeField]
  string sentence;
  public string Sentence { get {return sentence; } set { this.sentence = value;} }
  
  [SerializeField]
  string character_img;
  public string Character_Img { get {return character_img; } set { this.character_img = value;} }
  
  [SerializeField]
  string effect_sound;
  public string Effect_Sound { get {return effect_sound; } set { this.effect_sound = value;} }
  
  [SerializeField]
  int clueid;
  public int Clueid { get {return clueid; } set { this.clueid = value;} }
  
}