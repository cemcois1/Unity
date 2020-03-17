using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : ScriptableObject
{
    private int maxHealth;
    private int meleeDamage;
    private int rangeDamage;
    private int defance;
    private int attackRange;
    private int moveRange;
    private int runRange;
    private int completition = 100;
    private int info;
    private int meleeWeaponSkill;
    private int rangeWeaponSkill;
    private float regenerationSkill;

    public void setmaxHealth(int Health) { maxHealth = Health; }
    public int getMaxHealth() { return maxHealth;}

    public void setMeleeDamage(int Damage) { meleeDamage = Damage; }
    public int getMeleeDamage() { return meleeDamage; }

    public void setRangeDamage(int Damage) { rangeDamage = Damage; }
    public int getRangeDamage() { return rangeDamage; }


    public void setDefance(int defance) { this.defance=defance ; }
    public int getDefance() { return defance; }


    public void setAttackRange(int range) { attackRange = range; }
    public int getAttackrange() { return attackRange; }


    public void setMoveRange(int range) { moveRange = range; }
    public int getMoveRange() { return moveRange; }



}