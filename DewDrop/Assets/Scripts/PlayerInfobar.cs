﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfobar : MonoBehaviour, IInfobar
{
    private LivingThing target;

    public Vector3 worldOffset;
    public Vector3 UIOffset;


    private Text text_name;
    private Image image_health_fill;
    private Image image_health_delta;
    private Image image_mana_fill;

    private Image image_health_HoT;
    private Image image_health_DoT;

    private CanvasGroup canvasGroup;
    public void SetTarget(LivingThing target)
    {
        this.target = target;
    }

    private void Awake()
    {
        text_name = transform.Find("Name").GetComponent<Text>();
        image_health_fill = transform.Find("Health/Fill").GetComponent<Image>();
        image_health_delta = transform.Find("Health/Delta").GetComponent<Image>();
        image_mana_fill = transform.Find("Mana/Fill").GetComponent<Image>();
        image_health_HoT = transform.Find("Health/HoT").GetComponent<Image>();
        image_health_DoT = transform.Find("Health/DoT").GetComponent<Image>();
        canvasGroup = GetComponent<CanvasGroup>();

    }

    void LateUpdate()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        if (target.IsDead())
        {
            canvasGroup.alpha = 0;
        }
        else
        {
            canvasGroup.alpha = 1;
        }

        text_name.text = target.name;

        image_health_fill.fillAmount = target.currentHealth / target.maximumHealth;
        image_mana_fill.fillAmount = target.stat.currentMana / target.stat.finalMaximumMana;

        if (image_health_fill.fillAmount > image_health_delta.fillAmount) image_health_delta.fillAmount = image_health_fill.fillAmount;
        image_health_delta.fillAmount = Mathf.MoveTowards(image_health_delta.fillAmount, image_health_fill.fillAmount, 0.3f * Time.deltaTime);

        if (target.statusEffect.totalDamageOverTimeAmount > target.statusEffect.totalHealOverTimeAmount)
        {
            image_health_fill.fillAmount -= (target.statusEffect.totalDamageOverTimeAmount - target.statusEffect.totalHealOverTimeAmount) / target.maximumHealth;
            image_health_DoT.fillAmount = Mathf.Clamp(image_health_fill.fillAmount + (target.statusEffect.totalDamageOverTimeAmount - target.statusEffect.totalHealOverTimeAmount) / target.maximumHealth, 0f, target.currentHealth/target.maximumHealth);
            image_health_HoT.fillAmount = 0f;
        }
        else
        {
            image_health_DoT.fillAmount = 0f;
            image_health_HoT.fillAmount = image_health_fill.fillAmount + (target.statusEffect.totalHealOverTimeAmount - target.statusEffect.totalDamageOverTimeAmount) / target.maximumHealth;
        }

        transform.position = Camera.main.WorldToScreenPoint(target.transform.position + worldOffset) + UIOffset;


    }
}
