using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessing : MonoBehaviour
{
    private Volume v;
    private ChromaticAberration chromAb;
    private bool chromActive;
    private float chrom;

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
            chromActive = true;
            //chromAb.intensity.value = chromaticValue;
        }
        else
        {
            chromAb.intensity.value = 0f;
        }
    }

    private void Update()
    {
        if (chromActive)
        {
            if(chrom >= chromaticValue)
            {
                chromActive = false;
            }

            chrom += (chromaticValue - chrom) * .001f;
            chromAb.intensity.value = chrom;
        }
    }
}
