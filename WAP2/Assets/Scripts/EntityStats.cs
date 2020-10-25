using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class UnitStats
{
    [SerializeField]
    protected float baseHealthPointMax;
    protected float healthPointMax;
    [SerializeField]
    protected float healthPoint;
    protected float healthPointCoefficient = 1f;
    public float HealthPointMax
    {
        get => healthPointMax;
    }
    public float HealthPoint
    {
        get => healthPoint;
    }
    public bool IsDead
    {
        get
        {
            if (healthPoint <= 0)
                return true;
            else
                return false;
        }
    }

    public UnitStats(int maxHP)
    {
        baseHealthPointMax = maxHP;
        InitStats();
    }

    #region user function
    public void InitStats()
    {
        healthPointMax = (int)(baseHealthPointMax * healthPointCoefficient);
        healthPoint = healthPointMax;
    }

    public void InitStatsAsZero()
    {
        healthPointMax = (int)(baseHealthPointMax * healthPointCoefficient);
        healthPoint = 0;
    }

    public virtual void TakeDamage(float damage)
    {
        healthPoint -= damage;
    }

    public virtual void TakeHeal(float heal)
    {
        float leftHP = healthPointMax - healthPoint;
        if (leftHP != 0)
        {
            if (leftHP < heal)
            {
                healthPoint = healthPointMax;
                heal -= leftHP;
            }
            else
            {
                healthPoint += heal;
                return;
            }
        }
    }

    public void AdjustHealthPoint(float ratio)
    {
        float presntHPratioByMaxHP = healthPoint / healthPointMax;

        healthPointCoefficient += ratio;
        healthPointMax = (int)(baseHealthPointMax * healthPointCoefficient);
        healthPoint = (int)(healthPointMax * presntHPratioByMaxHP);
    }

    public void AdjustHealthPoint(int value)
    {
        float presntHPratioByMaxHP = healthPoint / healthPointMax;

        baseHealthPointMax += value;
        healthPointMax = (int)(baseHealthPointMax * healthPointCoefficient);
        healthPoint = (int)(healthPointMax * presntHPratioByMaxHP);
    }
    #endregion
}


public class EntityStats : MonoBehaviour
{
    #region variables
    [SerializeField]
    private UnitStats unitStat;

    public float HealthPointdrv
    {
        get => unitStat.HealthPoint;
    }
    public float HealthPointMax
    {
        get => unitStat.HealthPointMax;
    }
    #endregion
    #region user function
    public void TakeDamage(float damage)
    {
        unitStat.TakeDamage(damage);
        if (unitStat.IsDead)
            StartCoroutine(StartDyingAnimation());
    }

    private IEnumerator StartDyingAnimation()
    {
        yield break;
    }

    public void TakeHeal(int heal)
    {
        unitStat.TakeHeal(heal);
    }

    public void AdjustHealthPoint(int value)
    {
        unitStat.AdjustHealthPoint(value);
    }

    public void AdjustHealthPoint(float ratio)
    {
        unitStat.AdjustHealthPoint(ratio);
    }
    #endregion
    private void OnEnable()
    {
        unitStat.InitStats();
    }
}