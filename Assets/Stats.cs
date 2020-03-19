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
    private int completition;
    private int info;
    private int meleeWeaponSkill;
    private int rangeWeaponSkill;
    private float regenerationSkill;

    public void setmaxHealth(int Health) { maxHealth = Health; }
    public int getMaxHealth() { return maxHealth; }

    public void setMeleeDamage(int Damage) { meleeDamage = Damage; }
    public int getMeleeDamage() { return meleeDamage; }

    public void setRangeDamage(int Damage) { rangeDamage = Damage; }
    public int getRangeDamage() { return rangeDamage; }


    public void setDefance(int defance) { this.defance = defance; }
    public int getDefance() { return defance; }


    public void setAttackRange(int range) { attackRange = range; }
    public int getAttackrange() { return attackRange; }


    public void setMoveRange(int range) { moveRange = range; }
    public int getMoveRange() { return moveRange; }


    public void setrunRange(int range) { runRange = range; }
    public int getrunRange() { return runRange; }


    public void setcompletition(int newCompletitionValue) { completition = newCompletitionValue; }
    public int getcompletition() { return completition; }

    public void setinfo(int newValue) { info = newValue; }
    public int getinfo() { return info; }


    public void setmeleeWeaponSkill(int newMeleWeaponskill) { meleeWeaponSkill = newMeleWeaponskill; }
    public int getmeleeWeaponSkill() { return meleeWeaponSkill; }

    public void setrangeWeaponSkill(int newValue) { rangeWeaponSkill = newValue; }
    public int getrangeWeaponSkill() { return rangeWeaponSkill; }


    public void setregenerationSkill(int newValue) { regenerationSkill = newValue; }
    public float getregenerationSkill() { return regenerationSkill; }

}