using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScreen : MonoBehaviour
{

    public float duration = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
 
    }

    public IEnumerator shaking(float shakeValue)
    {
        float elapsed = 0f;
        Vector3 originalCamPos = Camera.main.transform.position;

        while (elapsed < duration)
        {
            float x = Random.Range(-shakeValue, shakeValue);
            float y = Random.Range(-shakeValue, shakeValue);

            Camera.main.transform.position = new Vector3(originalCamPos.x + x, originalCamPos.y + y, originalCamPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        Camera.main.transform.position = originalCamPos;

    }
}
