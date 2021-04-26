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
    [SerializeField] private GameObject blockDestroier;

    [SerializeField] private GameObject destroyLight;

    [SerializeField] private PowerUp powerUp;

    // Start is called before the first frame update
    void Start()
    {
        blockDestroier.SetActive(false);
        destroyLight.SetActive(false);
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
            WallBreak();
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
    //private IEnumerator WallBreak()
    //{
    //    playerCollider.enabled = false;
    //    blockDestroier.SetActive(true);
    //    yield return new WaitForSeconds(.2f);
    //    blockDestroier.SetActive(false);
    //    playerCollider.enabled = true;
    //}
    private void WallBreak()
    {
        RaycastHit2D raycast = Physics2D.Raycast(gameObject.transform.position + new Vector3(0, .5f), Vector2.up, 50);
        StartCoroutine(DestroyLight(raycast.distance));
        if (raycast.collider != null)
        {
            Destroy(raycast.transform.gameObject);
        }
    }

    private IEnumerator DestroyLight(float distance)
    {
        destroyLight.transform.localScale = new Vector3(.1f, distance);
        destroyLight.transform.localPosition = new Vector3(0, .5f + (distance / 2));
        destroyLight.SetActive(true);
        yield return new WaitForSeconds(.05f);
        destroyLight.SetActive(false);
    }


}
public enum PowerUp
{
    SlowMotion,
    SuperSpeed,
    WallBreak
}
