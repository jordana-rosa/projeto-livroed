using System.Collections.Generic; // Permite usar Listas
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Lista para armazenar todos os AudioSources que queremos controlar
    public List<AudioSource> audioSources;

    // Método que será chamado pelos botões para tocar um áudio específico
    public void PlayAudio(AudioSource selectedAudio)
    {
        // Parar todos os áudios antes de tocar o novo
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        // Tocar o áudio selecionado
        selectedAudio.Play();
    }
}
