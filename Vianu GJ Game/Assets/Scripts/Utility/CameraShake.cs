using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool shake = false;
    public float maxMagnitude;
    public float magnitude;

    public static CameraShake Instance{ get; private set; }

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        while(magnitude > 0)
            magnitude -= Time.deltaTime/2;

        if(!shake)
            return;

        while(magnitude<maxMagnitude)
            magnitude += Time.deltaTime/5;

        StartCoroutine(Shake());
        
    }

    public void StartShake(int duration)
    {
        shake = true;
        Invoke("StopShake", duration);
    }

    public void StopShake()
    {
        shake = false;
    }

    public IEnumerator Shake ()
    {
        Vector3 originalPos = transform.localPosition;

        while(shake)
        {
            //magnitude = Mathf.Min(magnitude + Time.deltaTime / 5, maxMagnitude);

            float x = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, originalPos.y  , originalPos.z);

            yield return null;
        }

        transform.localPosition = originalPos;

    }

}
