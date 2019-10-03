﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    // Cast spells are enabled gameobjects.
    // Otherwise, spells gameobjects are put on players disabled.

    public enum SpellTargetingType { None, Target, Direction, PointStrict, PointNonStrict }
    
    [Header("Spell Settings")]
    public SpellTargetingType targetingType;
    public LayerMask targetMask;
    public float range;
    public float cooldown;
    public bool isBasicAttack; // If set to true, the spell will repeat reserving itself.

    [Header("Spell Blueprint Properties")]
    public float remainingCooldown;

    [Header("Spell Instance Properties")]
    public Collider target; // Only used for SpellTargetingType 'Target'
    public Vector3 forwardVector; // Only used for SpellTargetingType 'Direction'
    public Vector3 point; // Only used for SpellTargetingType 'PointStrict', 'PointNonStrict'

    public bool isCooledDown
    {
        get
        {
            return remainingCooldown <= 0;
        }
    }
    public Player owner;

}
