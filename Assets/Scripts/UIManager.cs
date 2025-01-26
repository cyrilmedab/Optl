using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    // UI Panels
    public GameObject startingUI;
    public GameObject step1UI;
    public GameObject step2UI;
    public GameObject step3UI;
    public GameObject screenonUI;
    public GameObject safetycheckUI;
    public GameObject screenEmergencyUI;
    public GameObject stressmessageUI;
    public GameObject emergencyUI;
    public GameObject endUI;


    // Animator for pallet movement
    public Animator moveranimator;

      // Audio Components
    public AudioSource panelAudio; // AudioSource for UI sounds
    public AudioSource buttonAudio;
    public AudioSource conveyorBeltAudio;
    public AudioSource malfunctionAudio;
    public AudioSource alarmLoopAudio;


    // Timing Variables
    public float initialDelay = 3f; 
    public float stressdelay = 2f; 
    public float stressMessageDuration = 3f;
    public float emergencyUIdelay = 5f;


    private bool stressUITriggered = false; 
    private bool isFlashingLights = false;


     // Alarm Lights
    public GameObject alarmLightsPrefab; // Reference to the parent GameObject containing all lights
    public float lightFlashInterval = 0.5f; // Interval for toggling lights

    private void Start()
    {
        // Ensure all UI panels are initially deactivated
        startingUI.SetActive(false);
        step1UI.SetActive(false);
        step2UI.SetActive(false);
        step3UI.SetActive(false);
        screenonUI.SetActive(false);
        safetycheckUI.SetActive(false);
        screenEmergencyUI.SetActive(false);
        stressmessageUI.SetActive(false);
        emergencyUI.SetActive(false);
        endUI.SetActive(false);

        if (alarmLightsPrefab != null)
        {
            alarmLightsPrefab.SetActive(false);
        }

        // Start the coroutine to show the starting UI with a delay
        StartCoroutine(ShowStartingUIDelayed());
    }

    private IEnumerator ShowStartingUIDelayed()
    {
        yield return new WaitForSeconds(initialDelay);
        startingUI.SetActive(true);
        PlayPanelAudio();
    }

    public void EndAlarm()
    {
        StopAlarmAudio();
        endUI.SetActive(true);
        PlayPanelAudio();
        StopFlashingLights();
        emergencyUI.SetActive(false);
    }


    public void StartMachine()
    {
           Debug.Log("StartMachine button pressed!");

            step1UI.SetActive(false);
            step2UI.SetActive(true);
            screenonUI.SetActive(true);

            PlayButtonAudio();
    }

    private void Update()
    {
        if (moveranimator.GetCurrentAnimatorStateInfo(0).IsName("Pallet Move") && !stressUITriggered)
        {
            if (moveranimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                StartCoroutine(TriggerStressUIWithDelay());
                stressUITriggered = true;
                PlayMalfunctionAudio();
                StopConveyorAudio();
                PlayAlarmAudio();
                StartFlashingLights();

                safetycheckUI.SetActive(false);
                screenEmergencyUI.SetActive(true);
            }
        }
    }

    private void StopFlashingLights()
    {
        if (isFlashingLights)
        {
            isFlashingLights = false; // Stop the coroutine loop
            if (alarmLightsPrefab != null)
            {
                alarmLightsPrefab.SetActive(false); // Ensure the lights are turned off
            }
        }

    }


    private void StartFlashingLights()
    {
        if (!isFlashingLights && alarmLightsPrefab != null)
        {
            isFlashingLights = true;
            StartCoroutine(FlashLights());
        }
    }

    private IEnumerator FlashLights()
    {
        while (isFlashingLights)
        {
            alarmLightsPrefab.SetActive(true); // Turn all lights on
            yield return new WaitForSeconds(lightFlashInterval);
            alarmLightsPrefab.SetActive(false); // Turn all lights off
            yield return new WaitForSeconds(lightFlashInterval);
        }
    }

    private IEnumerator TriggerStressUIWithDelay()
    {
        yield return new WaitForSeconds(stressdelay);
        stressmessageUI.SetActive(true);
        yield return new WaitForSeconds(stressMessageDuration);
        stressmessageUI.SetActive(false);
        yield return new WaitForSeconds(emergencyUIdelay);
        emergencyUI.SetActive(true);
    }

    private void PlayPanelAudio()
    {
        if (panelAudio != null)
        {
            panelAudio.Play();
        }
    }

    private void PlayButtonAudio()
    {
        if (buttonAudio != null)
        {
            buttonAudio.Play();
        }
    }

    private void StopConveyorAudio()
{
    if (conveyorBeltAudio != null)
    {
        conveyorBeltAudio.Stop();
    }
}

     private void PlayMalfunctionAudio()
    {
        if (malfunctionAudio != null)
        {
            malfunctionAudio.Play();
        }
    }

      private void PlayAlarmAudio()
    {
        if (alarmLoopAudio != null)
        {
            alarmLoopAudio.Play();
        }
    }

    private void StopAlarmAudio()
    {
        if (alarmLoopAudio != null)
        {
            alarmLoopAudio.Stop();
        }
    }
}
