using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    public AudioSource audioSource;
    public Button pauseResumeButton;

    private bool isPaused = false;

    void Start()
    {
        // Adiciona um listener ao botão
        pauseResumeButton.onClick.AddListener(ToggleAudio);
    }

    void ToggleAudio()
    {
        if (isPaused)
        {
            audioSource.UnPause();
            pauseResumeButton.GetComponentInChildren<Text>().text = "Pausar";
        }
        else
        {
            audioSource.Pause();
            pauseResumeButton.GetComponentInChildren<Text>().text = "Retomar";
        }

        isPaused = !isPaused;
    }
}
