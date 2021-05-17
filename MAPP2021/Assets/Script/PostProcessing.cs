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
    private bool chromRestore;
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
            chrom = 0f;
            chromActive = true;
            //chromAb.intensity.value = chromaticValue;
        }
        else
        {
            chromRestore = true;
            chrom = chromaticValue;
            //chromAb.intensity.value = 0f;
        }
    }

    private void Update()
    {
        if (chromActive)
        {
            print(chrom);
            if(chrom >= chromaticValue)
            {
                chromActive = false;
            }

            chrom += (chromaticValue - chrom) * .01f;
            chromAb.intensity.value = chrom;
        }

        if (chromRestore)
        {
            if (chrom <= .1f)
            {
                chrom = 0f;
                chromRestore = false;
            }

            chrom += (0f - chrom) * .03f;
            chromAb.intensity.value = chrom;
        }
        print(chromRestore);
    }
}
