using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "karakterdenemeleri", menuName = "Character", order = 0)]
public class Character : ScriptableObject
{
    [SerializeField] int health;
    [SerializeField] string Name;
    [SerializeField] string tag;
    [SerializeField] Dictionary<string, Animation> animationlist;
    [SerializeField] Stats characterstats;
    [SerializeField] Dictionary<string, AudioSource> soundList;
    [SerializeField] GameObject karkater;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Dictionary<string, Animation> effectoncharacter;

}
