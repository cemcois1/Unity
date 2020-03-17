using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter : ScriptableObject
{
    private int health;
    private string name;
    private string tag;
    private Dictionary<string, Animation> animationlist;
    private Stats characterstats;
    private Dictionary<string, AudioSource> soundList;
    private GameObject karkater;
    private Rigidbody rigidbody;
    private Dictionary<string, Animation> effectoncharacter;
}
