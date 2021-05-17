using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessing : MonoBehaviour
{
    private Volume v;
    private ChromaticAberration chromAb;

    [Range(0f, 1f)]
    public float chromaticValue;

    private void Start()
    {
        v = GetComponent<Volume>();
        v.profile.TryGet(out chromAb);
    }

    public void ChromaticAbberation(bool isOn)
    {
        if (isOn)
        {
            chromAb.intensity.value = chromaticValue;
        }
        else
        {
            chromAb.intensity.value = 0f;
        }
    }
}
