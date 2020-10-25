using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class WaitSecondContainer
{
    private static Dictionary<float, WaitForSeconds> waitForSecondsByTime = new Dictionary<float, WaitForSeconds>();
    public static WaitForSeconds GetWaitForSecondOf(float second)
    {
        if (waitForSecondsByTime.ContainsKey(second) == false)
            waitForSecondsByTime.Add(second, new WaitForSeconds(second));
        return waitForSecondsByTime[second];
    }
}


 class Projectile : MonoBehaviour
{
    protected float damage;
    protected int targetLayer;
    
    [SerializeField]
    protected float surviveDuration = 1.5f;

    public void SetProjectileInfo(float damage, int targetLayer)
    {
        this.damage -= damage;
        this.targetLayer = targetLayer;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == targetLayer)
        {
            var entity = GetComponent<EntityStats>();
            if (entity)
                entity.TakeDamage(damage);
        }
    }

    protected IEnumerator CountProjectileLife()
    {
        yield return WaitSecondContainer.GetWaitForSecondOf(surviveDuration);
        if (gameObject.activeSelf)
            gameObject.SetActive(false);
    }

    protected virtual void OnEnable()
    {
        StartCoroutine(CountProjectileLife());
    }

}

