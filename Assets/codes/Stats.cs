using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "StatExamples", menuName = "Statpoints", order = 3)]
public class Stats : ScriptableObject
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int meleeDamage;
    [SerializeField] private int rangeDamage;
    [SerializeField] private int defance;
    [SerializeField] private int attackRange;
    [SerializeField] private int moveRange;
    [SerializeField] private int runRange;
    [SerializeField] private int completition;
    [SerializeField] private int info;
    [SerializeField] private int meleeWeaponSkill;
    [SerializeField] private int rangeWeaponSkill;
    [SerializeField] private int reflex;
    [SerializeField] private float regenerationSkill;

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


    public void setReflex(int reflex) { this.reflex = reflex; }
    public int getReflex() { return this.reflex; }


    public void setregenerationSkill(int newValue) { regenerationSkill = newValue; }
    public float getregenerationSkill() { return regenerationSkill; }

}