using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStat : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] float currentHealth = 100;
    [SerializeField] ParticleSystem deathEffect;

    public event System.Action<float> OnHealthPercentChanged;
    public event System.Action OnDamaged;
    public event System.Action OnDeath;


    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
        OnHealthPercentChanged?.Invoke(currentHealth);
    }

    public void DealDamage(float damage)
    {
        if(damage < 0) {return;}

        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeath?.Invoke();
            
            ParticleSystem particleSystem = Instantiate<ParticleSystem>(deathEffect, transform.position, transform.rotation);
            Destroy(particleSystem, 0.5f);
            Destroy(this.gameObject);
        }

        OnHealthPercentChanged?.Invoke(currentHealth/maxHealth);
        OnDamaged?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
