using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;

    private void Start()
    {
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = 1;
        healthBar.value = 1;
    }

    public void SetHealth(float hp)
    {
        healthBar.value = hp;
    }
}