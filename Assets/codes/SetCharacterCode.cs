using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Stat:int
{
    maxHealth = 0,
    meleeDamage = 1,
    rangeDamage = 2,
    defence = 3,
    attackRange = 4,
    moveRange = 5,
    runRange = 6,
    completition = 7,
    info = 8,
    meleeWeaponSkill = 9,
    rangeWeaponSkill = 10,
    reflex = 11,
    actionPoint = 12,
    regenerationSkill = 13
}


public class SetCharacterCode : MonoBehaviour
{
    public Character CV;
    public GameObject characterprefab;
    private CharacterValueControlCode code;

    void Start()
    {/*
        GameObject karakterim = Instantiate(characterprefab);
        code = karakterim.GetComponent<CharacterValueControlCode>();
        code.health = CV.health;
        code.name= CV.name;
        code.tag= CV.tag;
        code.animationlist= CV.animationlist;
        code.characterstats= CV.characterstats;
        code.soundList= CV.soundList;
        code.CharacterGO= CV.CharacterGO;
        code.effectoncharacter = CV.effectoncharacter;
    */
    }
}
