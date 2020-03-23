using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu( menuName = "Character", order = 0)]
public class Character : ScriptableObject
{
    [SerializeField] public int health;
    [SerializeField] public string name;
    [SerializeField] public string tag;
    [SerializeField] public Dictionary<string, Animation> animationlist;
    [SerializeField] public Stats characterstats;
    [SerializeField] public Dictionary<string, AudioSource> soundList;
    [SerializeField] public GameObject CharacterGO;
    [SerializeField] public Dictionary<string, Animation> effectoncharacter;

}
