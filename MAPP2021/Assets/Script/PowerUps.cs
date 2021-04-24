using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private float slowMotionFactor = .5f;
    [SerializeField] private float slowMotionTime = 6f;

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float SuperSpeedFactor = 1.5f;
    [SerializeField] private float SuperSpeedTime = 6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPressActivate(PowerUp powerUp)
    {
        if(powerUp == PowerUp.SlowMotion)
        {
            StartCoroutine(SlowMotion());
        }
        if(powerUp == PowerUp.SuperSpeed)
        {
            StartCoroutine(SuperSpeed());
        }
        if(powerUp == PowerUp.WallBreak)
        {

        }
    }

    private IEnumerator SlowMotion()
    {
        Time.timeScale = slowMotionFactor;
        yield return new WaitForSeconds(slowMotionTime);
        Time.timeScale = 1;
    }

    private IEnumerator SuperSpeed()
    {
        playerMovement.SetMovementSpeed(SuperSpeedFactor);
        yield return new WaitForSeconds(SuperSpeedTime);
        playerMovement.ResetMovementSpeed();
    }
    private void WallBreak()
    {

    }


}
public enum PowerUp
{
    SlowMotion,
    SuperSpeed,
    WallBreak
}
