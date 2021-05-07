using System.Collections;
using System.Collections.Generic;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class ColourChange : MonoBehaviour
{
    [SerializeField] private BlockSpeed blockSpeed;
    [SerializeField] private Image image;
    [SerializeField] private float startSecondsPerLoop = 10f;
    [Header("Sätt till 1 för att inte ändra mättnad")]
    [Range(0.0f, 1.0f)]
    [SerializeField] private float minimumSaturation;
    [Header("Om false: loopar genom färghjulet, mättnad fast på 1")]
    [Header("Om true: slumpmäsig färg")]
    [SerializeField] private bool randomNewColor;
    [SerializeField] private bool increaseSpeedTogetherWithBlockSpeed;


    [SerializeField] private float secondsPerLoop;
    private float startSpeed;

    private float previousHue = 0;
    private float previousSaturation = 1;
    //private float previousValue = 0;
    private float currentHue = 1;
    private float currentSaturation = 1;
    private float currentValue = 1;
    private float nextHue = 1;
    private float nextSaturation = 1;
    //private float nextValue = 1;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (randomNewColor)
        {
            previousHue = Random.value;
            previousSaturation = Random.Range(minimumSaturation, 1);
            //previousValue = Random.value;
            nextHue = Random.value;
            nextSaturation = Random.Range(minimumSaturation, 1);
            //nextValue = Random.value;
        }
        secondsPerLoop = startSecondsPerLoop;
        startSpeed = blockSpeed.GetStartSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (increaseSpeedTogetherWithBlockSpeed)
        {
            secondsPerLoop = startSecondsPerLoop * (startSpeed/ blockSpeed.GetSpeed());
        }
        timer += Time.deltaTime;
        currentHue = Mathf.Lerp(previousHue, nextHue, timer/ secondsPerLoop);
        currentSaturation = Mathf.Lerp(previousSaturation, nextSaturation, timer / secondsPerLoop);
        //currentValue = Mathf.Lerp(previousValue, nextValue, timer / secondsPerLoop);
        image.color = Color.HSVToRGB(currentHue, currentSaturation, currentValue) - new Color(0, 0, 0, 0.5f);
        if (timer / secondsPerLoop >= 1)
        {
            timer = 0;
            if (randomNewColor)
            {
                previousHue = nextHue;
                previousSaturation = nextSaturation;
                //previousValue = nextValue;
                nextHue = Random.value;
                nextSaturation = Random.Range(minimumSaturation, 1);
                //nextValue = Random.value;
            }
        }
    }
}
