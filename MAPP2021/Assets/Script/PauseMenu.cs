
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

   [SerializeField] private GameObject pauseMenuUI;
   [SerializeField] private GameObject pauseButton;
   [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject powerUpButton;

    private bool isPaused;
    private float borderVol;
    private AudioUI audioUI;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        optionsMenu.SetActive(false);
        audioUI = FindObjectOfType<AudioUI>();
    }

    public void Resume()
    {
        isPaused = false;

        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        powerUpButton.SetActive(true);
        Time.timeScale = 1f;

        FindObjectOfType<AudioUI>().SFXMixer.SetFloat("GrindVolume", borderVol);
    }

    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        optionsMenu.SetActive(false);
        powerUpButton.SetActive(false);
       
        Time.timeScale = 0f;

        isPaused = true;

        FindObjectOfType<AudioUI>().SFXMixer.GetFloat("GrindVolume", out float currentVol);
        borderVol = currentVol;
        FindObjectOfType<AudioUI>().SFXMixer.SetFloat("GrindVolume", -80f);
        FindObjectOfType<AudioUI>().SetHiPass();
    }

    public void Restart()
    {
        isPaused = false;

        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        audioUI.RestartPitch();
    }

    public void LoadMenu()
    {
        isPaused = false;

        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Options()
    {
        pauseMenuUI.SetActive(false);
        optionsMenu.SetActive(true);
        
    }

    public void BackToPauseScreen()
    {
        optionsMenu.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public bool GetIsPaused()
    {
        return isPaused;
    }
}
