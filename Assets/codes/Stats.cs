using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "StatExamples", menuName = "Statpoints", order = 3)]

public class Stats : ScriptableObject
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int meleeDamage;
    [SerializeField] private int rangeDamage;
    [SerializeField] private int defence;
    [SerializeField] private int attackRange;
    [SerializeField] private int moveRange;
    [SerializeField] private int runRange;
    [SerializeField] private int completition;
    [SerializeField] private int info;
    [SerializeField] private int meleeWeaponSkill;
    [SerializeField] private int rangeWeaponSkill;
    [SerializeField] private int reflex;
    [SerializeField] private int actionPoint;
    [SerializeField] private float regenerationSkill;

    public type getStat<type>(Stat name) {
        System.Object retValue = 0;

        switch ((int)name) {
            case 0:
                retValue = this.maxHealth;
                return (type)retValue;

            case 1:
                retValue = this.meleeDamage;
                return (type)retValue;

            case 2:
                retValue = this.rangeDamage;
                return (type)retValue;

            case 3:
                retValue = this.defence;
                return (type)retValue;

            case 4:
                retValue = this.attackRange;
                return (type)retValue;

            case 5:
                retValue = this.moveRange;
                return (type)retValue;

            case 6:
                retValue = this.runRange;
                return (type)retValue;

            case 7:
                retValue = this.completition;
                return (type)retValue;

            case 8:
                retValue = this.info;
                return (type)retValue;

            case 9:
                retValue = this.meleeWeaponSkill;
                return (type)retValue;

            case 10:
                retValue = this.rangeWeaponSkill;
                return (type)retValue;

            case 11:
                retValue = this.reflex;
                return (type)retValue;

            case 12:
                retValue = this.actionPoint;
                return (type)retValue;

            case 13:
                retValue = this.regenerationSkill;
                return (type)retValue;

            default:
                return (type)retValue;
        }

    }

    public void setStat<type>(Stat name , type value)
    {
        System.Object retValue = value;

        switch ((int)name)
        {
            case 0:
                this.maxHealth = (int)retValue ;
                break;

            case 1:
                this.meleeDamage = (int)retValue;
                break;

            case 2:
                this.rangeDamage = (int)retValue;
                break;

            case 3:
                this.defence = (int)retValue;
                break;

            case 4:
                this.attackRange = (int)retValue;
                break;

            case 5:
                this.moveRange = (int)retValue;
                break;

            case 6:
                this.runRange = (int)retValue;
                break;

            case 7:
                this.completition = (int)retValue;
                break;

            case 8:
                this.info = (int)retValue;
                break;

            case 9:
                this.meleeWeaponSkill = (int)retValue;
                break;

            case 10:
                this.rangeWeaponSkill = (int)retValue;
                break;

            case 11:
                this.reflex = (int)retValue;
                break;

            case 12:
                this.actionPoint = (int)retValue;
                break;

            case 13:
                this.regenerationSkill = (float)retValue;
                break;

            default:
                break;
        }

    }

}