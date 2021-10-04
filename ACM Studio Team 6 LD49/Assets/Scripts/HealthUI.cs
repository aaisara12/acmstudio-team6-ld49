using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] HealthStat healthStat;
    [SerializeField] UnityEngine.UI.Slider slider;

    void Awake()
    {
        healthStat.OnHealthPercentChanged += HandleNewPercentHealth;
    }


    void HandleNewPercentHealth(float newHealthPercent)
    {
        slider.value = newHealthPercent;
    }
}
