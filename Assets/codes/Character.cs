using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu( menuName = "Character", order = 0)]
public class Character : ScriptableObject
{
    [SerializeField] private int health;
    [SerializeField] private string Name;
    [SerializeField] private string tag;
    [SerializeField] private Dictionary<string, Animation> animationlist;
    [SerializeField] private Stats characterstats;
    [SerializeField] private Dictionary<string, AudioSource> soundList;
    [SerializeField] private GameObject CharacterGO;
    [SerializeField] private Dictionary<string, Animation> effectoncharacter;

}
