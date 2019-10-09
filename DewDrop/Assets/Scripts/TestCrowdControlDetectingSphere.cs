﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCrowdControlDetectingSphere : MonoBehaviour
{
    private new Renderer renderer;
    private LivingThing livingThing;

    public StatusEffectType detect;
    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        livingThing = GetComponentInParent<LivingThing>();
    }

    // Update is called once per frame
    void Update()
    {
        renderer.enabled = livingThing.statusEffect.IsAffectedBy(detect);
    }
}
