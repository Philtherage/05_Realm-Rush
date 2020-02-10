using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{

    [SerializeField] int health = 100;
    [SerializeField] Slider baseHealthSlider;

    // Start is called before the first frame update
    void Start()
    {   
        SetupHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayBaseHealth();
    }

    private void SetupHealthBar()
    {
        baseHealthSlider.minValue = 0;
        baseHealthSlider.maxValue = health;
        baseHealthSlider.value = health;
    }

    private void DisplayBaseHealth()
    {       
        baseHealthSlider.value = health;
    }

    public void DamageBase(int damage)
    {
        health -= damage;
    }
}
