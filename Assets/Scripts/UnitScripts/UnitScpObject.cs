using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit",menuName = "Unit")]
public class UnitScpObject : ScriptableObject
{
    public int maxHP = 3;
    public int currentHP = 3;
    public float wanderRadius = 10;
    public float wanderTimer = 3;
    public string m_name = "";
}
