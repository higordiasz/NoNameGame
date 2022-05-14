using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tocha : MonoBehaviour
{
    public static Light light;
    private static bool rodando = false;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        InvokeRepeating("LightEfect", .01f, 1.5f);
    }

    void LightEfect()
    {
        if (rodando)
            return;
        //rodando = true;
        float range = light.range;
        float newRange = Random.Range(6.0f, 20.0f);
        if (newRange > range)
        {
            StartCoroutine(LoopAdd(newRange, range));
        }
        else
        {
            StartCoroutine(LoopSub(newRange, range));
        }
        return;
    }

    IEnumerator LoopAdd(float newRange, float range)
    {

        while (newRange > range)
        {
            range += 0.1f;
            light.range = range;
            yield return new WaitForSeconds(0.3f);
        }
        //rodando = false;
    }

    IEnumerator LoopSub(float newRange, float range)
    {
        while (range > newRange)
        {
            range -= 0.1f;
            light.range = range;
            yield return new WaitForSeconds(0.3f);
        }
        //rodando = false;
    }
}
