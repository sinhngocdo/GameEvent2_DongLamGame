using System;
using System.Collections;
using UnityEngine;

public class ObstacleNetwork : MonoBehaviour
{
    #region <====================| PROPERTIES |====================>
    
    [SerializeField]
    protected int currentHealth;
    
    [SerializeField]
    protected HittableStatus hittableStatus;

    [SerializeField]
    protected GameObject[] deadSteps;

    protected bool isDestroyed;
    
    public event Action<int> OnHealthChanged;
    public event Action<bool> OnDead; 
    
    #endregion <=============================================>
    
    #region <====================| UNITY CORE |====================>

    protected virtual void OnEnable()
    {
        isDestroyed = false;
        currentHealth = hittableStatus.Health;
        deadSteps.ActiveStep(0);
    }

    #endregion <=============================================>
    
    #region <====================| MAIN HANDLE |====================>
    
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= (damage - hittableStatus.Armor);
        OnHealthChanged?.Invoke(currentHealth);
        
        if (currentHealth <= 0)
        {
            deadSteps.ActiveStep(2);
            isDestroyed = true;
            OnDead?.Invoke(true);
            OnDestroy();
        }
        else if (hittableStatus.LowHealthPercent >= (float)currentHealth / hittableStatus.Health)
        {
            deadSteps.ActiveStep(1);
        }
    }

    public void OnDestroy()
    {
        StartCoroutine(HideObject());
        return;

        IEnumerator HideObject()
        {
            yield return new WaitForSeconds(5);
            this.gameObject.SetActive(false);
        }
    }
    
    #endregion <=============================================>
}
