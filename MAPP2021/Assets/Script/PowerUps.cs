using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private float chansForSlowMotion;
    [SerializeField] private float chansForSuperSpeed;
    [SerializeField] private float chansForBlockDestroier;
    [SerializeField] private float chansForBomb;
    [SerializeField] private float poweringUpTime = 7f;

    [SerializeField] private Text powerText;

    [SerializeField] private float slowMotionFactor = .5f;
    [SerializeField] private float slowMotionTime = 6f;

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float SuperSpeedFactor = 1.5f;
    [SerializeField] private float SuperSpeedTime = 6f;

    [SerializeField] private CircleCollider2D playerCollider;
    [SerializeField] private GameObject blockDestroier;

    [SerializeField] private GameObject destroyLight;

    [SerializeField] private PowerUp powerUp;

    [SerializeField] private Button powerUpButton;

    private float powerUpPicker;

    // Start is called before the first frame update
    void Start()
    {
        blockDestroier.SetActive(false);
        destroyLight.SetActive(false);
        PickPowerUp();
    }


    public void OnPressActivate()
    {
        if(powerUp == PowerUp.SlowMotion)
        {
            StartCoroutine(SlowMotion());
            FindObjectOfType<AudioManager>().Play("SlowMotion");
        }
        if(powerUp == PowerUp.SuperSpeed)
        {
            StartCoroutine(SuperSpeed());
        }
        if(powerUp == PowerUp.WallBreak)
        {
            WallBreak();
            FindObjectOfType<AudioManager>().Play("WallBreak");
        }
        if(powerUp == PowerUp.Bomb)
        {
            Bomb();
        }
        powerUpButton.interactable = false;
        StartCoroutine(PoweringUp());

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

    private void Bomb()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Obstacle Block");
        foreach (GameObject o in blocks)
        {
            Destroy(o);
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

    private IEnumerator PoweringUp()
    {
        yield return new WaitForSeconds(poweringUpTime);
        powerUpButton.interactable = true;
        PickPowerUp();
    }

    private void PickPowerUp()
    {
        powerUpPicker = Random.value;
        if (powerUpPicker < chansForSlowMotion)
        {
            powerUp = PowerUp.SlowMotion;
            powerText.text = "Slow Motion";
        }
        else if (powerUpPicker < chansForSuperSpeed)
        {
            powerUp = PowerUp.SuperSpeed;
            powerText.text = "Super Speed";
        }
        else if (powerUpPicker < chansForSlowMotion)
        {
            powerUp = PowerUp.WallBreak;
            powerText.text = "Wall Break";
        }
        else if (powerUpPicker <= chansForBomb)
        {
            powerUp = PowerUp.Bomb;
            powerText.text = "Bomb";
        }
    }


}
public enum PowerUp
{
    SlowMotion,
    SuperSpeed,
    WallBreak,
    Bomb
}
