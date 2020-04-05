using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterValueControlCode : MonoBehaviour
{
    public int health;
    public Dictionary<string, Animation> animationlist;
    public Stats characterstats;
    public Dictionary<string, AudioSource> soundList;
    public GameObject CharacterGO;
    public Dictionary<string, Animation> effectoncharacter;
}