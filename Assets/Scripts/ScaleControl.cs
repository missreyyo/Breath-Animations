using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleControl : MonoBehaviour
{
    public float scaleValue = 0.5f; 
    public float scaleStep = 0.1f; 
    public float scaleTarget = 1.0f; 
    public float breathHold = 5.0f;

    private void Start()
    {
        StartCoroutine(ScaleLoop());
    }

    private IEnumerator ScaleLoop()
    {
        while (true)
        {
            
            while (scaleValue < scaleTarget)
            {
                scaleValue += scaleStep;
                transform.localScale = new Vector3(scaleValue, scaleValue, 1.0f);
                yield return new WaitForSeconds(1.0f);
            }

            
            yield return new WaitForSeconds(breathHold);

            
            while (scaleValue > 0.5f)
            {
                scaleValue -= scaleStep;
                transform.localScale = new Vector3(scaleValue, scaleValue, 1.0f);
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}