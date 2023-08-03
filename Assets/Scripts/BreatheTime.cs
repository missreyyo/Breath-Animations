using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BreatheTime : MonoBehaviour
{
    public TextMeshPro textComponent;
    public int breathIncount = 5;
    public int breathHoldCount = 5;
    public int breathOutCount = 5;
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
                textComponent.text = "Nefes Al " + breathIncount;
                breathIncount--;

                if (breathIncount < 1)
                {
                    isBreathing = false;
                    isHoldingBreath = true;
                }
            }
            else if (isHoldingBreath)
            {
                textComponent.text = "Nefesini Tut " + breathHoldCount;
                breathHoldCount--;

                if (breathHoldCount < 1)
                {
                    isHoldingBreath = false;
                    isBreathing = false;
                }
            }
            else
            {
                textComponent.text = "Nefes Ver " + breathOutCount;
                breathOutCount--;

                if (breathOutCount < 1)
                {
                    isBreathing = true;
                    isHoldingBreath = false;
                }
            }

            yield return new WaitForSeconds(1.0f);
        }
    }
}