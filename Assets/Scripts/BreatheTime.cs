using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BreatheTime : MonoBehaviour
{
    public TextMeshPro textComponent;
    private int count = 5;
    private bool isBreathing = true;
    private bool isHoldingBreath = false;

    private void Start()
    {
        StartCoroutine(BreathLoop());
    }

    private IEnumerator BreathLoop()
    {
        while (true)
        {
            if (isBreathing)
            {
                textComponent.text = "Nefes Al " + count;
                count--;

                if (count < 1)
                {
                    count = 5;
                    isBreathing = false;
                    isHoldingBreath = true;
                }
            }
            else if (isHoldingBreath)
            {
                textComponent.text = "Nefesini Tut " + count;
                count--;

                if (count < 1)
                {
                    count = 5;
                    isHoldingBreath = false;
                    isBreathing = false;
                }
            }
            else
            {
                textComponent.text = "Nefes Ver " + count;
                count--;

                if (count < 1)
                {
                    count = 5;
                    isBreathing = true;
                    isHoldingBreath = false;
                }
            }

            yield return new WaitForSeconds(1.0f);
        }
    }
}