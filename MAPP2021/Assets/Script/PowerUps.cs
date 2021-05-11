using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private BombEffect bombEffect;

    [SerializeField] private CameraShake cameraShake;

    [SerializeField] private PostProcessing postProcessing;
    [SerializeField] private AudioUI audioUI;

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

    [SerializeField] private float secondsOfLightBombEffect;
    [SerializeField] private float secondsOfShakeBombEffect;
    [SerializeField] private float bombShakeMagnitud;
    [SerializeField] private int deltaTimePerShake;
    [SerializeField] private float blockParticulsPerSquearUnit;
    [SerializeField] private float explotionSpeed;

    [SerializeField] private ParticleSystemForceField forceField;
    [SerializeField] private float forceFeildStrength;

    [SerializeField] ChangeImage changeImage;


    private float powerUpPicker;

    // Start is called before the first frame update
    void Start()
    {
        blockDestroier.SetActive(false);
        destroyLight.SetActive(false);
        PickPowerUp();
        forceField.endRange = Camera.main.orthographicSize * 2;
        forceField.gravity = 0;
    }


    public void OnPressActivate()
    {
        if(powerUp == PowerUp.SlowMotion)
        {
            Debug.Log(1);
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
        audioUI.SetGamePitch();
        postProcessing.ChromaticAbberation(true);
        Time.timeScale = slowMotionFactor;
        yield return new WaitForSeconds(slowMotionTime);
        Time.timeScale = 1;
        postProcessing.ChromaticAbberation(false);
        audioUI.RestoreGamePitch();
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
            
            //o.GetComponent<BoxCollider2D>().enabled = false;
            //o.GetComponent<SpriteRenderer>().enabled = false;
            o.GetComponent < BoxMovement > ().BlowingUp(transform, explotionSpeed);
            //ParticleSystem p = o.GetComponent<ParticleSystem>();
            //var e = p.emission;
            //e.rateOverTime = p.transform.position.x * p.transform.position.y * blockParticulsPerSquearUnit;
            //p.Play();
        }
        //StartCoroutine(ShockWave());
        StartCoroutine(bombEffect.BombHasGoneOf(secondsOfLightBombEffect));
        StartCoroutine(cameraShake.ShakeCamera(secondsOfShakeBombEffect, bombShakeMagnitud, deltaTimePerShake));
    }

    private IEnumerator DestroyLight(float distance)
    {
        destroyLight.transform.localScale = new Vector3(.05f, distance);
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
            changeImage.setSprite(PowerUp.SlowMotion);
            
            
        }
//         else if (powerUpPicker < chansForSuperSpeed)
//         {
//             powerUp = PowerUp.SuperSpeed;
//             powerText.text = "Super Speed";
//         }
        else if (powerUpPicker < chansForBlockDestroier)
        {
            powerUp = PowerUp.WallBreak;
            powerText.text = "Wall Break";
            changeImage.setSprite(PowerUp.WallBreak);
            
        }
        else if (powerUpPicker <= chansForBomb)
        {
            powerUp = PowerUp.Bomb;
            powerText.text = "Bomb";
            changeImage.setSprite(PowerUp.Bomb);
            
        }
    }

    private IEnumerator ShockWave()
    {
        forceField.gravity = -forceFeildStrength;
        yield return new WaitForSeconds(.5f);
        forceField.gravity = 0;
    }



}
public enum PowerUp
{
    SlowMotion,
    SuperSpeed,
    WallBreak,
    Bomb
}
