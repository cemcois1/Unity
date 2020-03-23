using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharacterCode : MonoBehaviour
{
    public Character CV;
    public GameObject characterprefab;
    private CharacterValueControlCode code;

    void Start()
    {
        GameObject karakterim = Instantiate(characterprefab);
        code= karakterim.GetComponent<CharacterValueControlCode>();
        code.health = CV.health;
        code.name= CV.name;
        code.tag= CV.tag;
        code.animationlist= CV.animationlist;
        code.characterstats= CV.characterstats;
        code.soundList= CV.soundList;
        code.CharacterGO= CV.CharacterGO;
        code.effectoncharacter = CV.effectoncharacter;
    }
}
