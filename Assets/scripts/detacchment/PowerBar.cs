using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public Slider slider;
    int maxPower = 5;
    public float currentPower;
    float interval = 0.125f;
    float nextTime = 0;
    bool goingDown = true;
    public Gradient gradient;
    public Image fill;

    public static bool weak = false;
    public static bool mid = false;
    public static bool strong = false;

    // Start is called before the first frame update
    void Start()
    {
        currentPower = maxPower;
        fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentPower;
        fill.color = gradient.Evaluate(slider.normalizedValue);

        if (Time.time >= nextTime && goingDown == true)
        {
            Decrease();
            nextTime += interval;
        }

        if (Time.time >= nextTime && goingDown == false)
        {
            Increase();
            nextTime += interval;
        }
        if (currentPower == 0)
        {
            goingDown = false;
        }
        if (currentPower == maxPower)
        {
            goingDown = true;
        }

        if(currentPower == 3)
        {
            strong = true;
            mid = false;
            weak = false;
        }
        else if (currentPower < 3 && currentPower >= 2 || currentPower > 3 && currentPower <= 4)
        {
            strong = false;
            mid = true;
            weak = false;
        }
        else if (currentPower < 2 && currentPower >= 0 || currentPower > 4 && currentPower <= 5)
        {
            weak = true;
            mid = false;
            strong = false;
        }

    }

    void Decrease()
    {
        goingDown = true;
        currentPower -= 0.5f;
    }
    
    void Increase()
    {
        if(currentPower <= maxPower)
        {
        currentPower += 0.5f;
        }
    }

    public void DeactivateBar()
    {
        gameObject.SetActive(false);
    }

    /*
    void SetPower()
    {
        slider.value = currentPowerPower;

    }
    

    void SetMaxPower()
    {
        slider.maxValue = maxPower;
        slider.value = currentPower;
    }
    */
}





