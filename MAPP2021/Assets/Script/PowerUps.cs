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

    [SerializeField] private CircleCollider2D playerCollider;
    [SerializeField] private BoxCollider2D blockDestroier;

    [SerializeField] private PowerUp powerUp;

    // Start is called before the first frame update
    void Start()
    {
        blockDestroier.enabled = false;
    }


    public void OnPressActivate()
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
            StartCoroutine(WallBreak());
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
    private IEnumerator WallBreak()
    {
        playerCollider.enabled = false;
        blockDestroier.enabled = true;
        yield return new WaitForSeconds(1);
        blockDestroier.enabled = false;
        playerCollider.enabled = true;
    }


}
public enum PowerUp
{
    SlowMotion,
    SuperSpeed,
    WallBreak
}
