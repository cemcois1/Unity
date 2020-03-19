using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter : ScriptableObject
{
    private int health { get; set; }
    private string Name { get; set; }
    private string tag { get; set; }
    private Dictionary<string, Animation> animationlist { get; set; }
    private Stats characterstats { get; set; }
    private Dictionary<string, AudioSource> soundList { get; set; }
    private GameObject karkater { get; set; }
    private Rigidbody rigidbody { get; set; }
    private Dictionary<string, Animation> effectoncharacter { get; set; }
}
