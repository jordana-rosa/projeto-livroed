using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnClickArea : MonoBehaviour
{
    public AudioClip baco, cabeca, cauda, corpo, pancreas, veiacava, vesicula;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Para toque em dispositivos móveis
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Pega o primeiro toque
            if (touch.phase == TouchPhase.Began)
            {
                HandleInput(touch.position);
            }
        }

        // Para cliques de mouse (para testes no Unity)
        if (Input.GetMouseButtonDown(0))
        {
            HandleInput(Input.mousePosition);
        }
    }

    // Função para tratar a entrada de toque ou clique
    void HandleInput(Vector3 inputPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        RaycastHit hit;

        // Verifica se o toque ou clique atingiu um Collider
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                // Para qualquer áudio em reprodução antes de tocar o próximo
                audioSource.Stop();

                // Identifica qual objeto foi tocado e toca o áudio correspondente
                string clickedObject = hit.collider.gameObject.name;

                switch (clickedObject)
                {
                    case "Baco":
                        audioSource.PlayOneShot(baco);
                        break;
                    case "Cabeca":
                        audioSource.PlayOneShot(cabeca);
                        break;
                    case "Cauda":
                        audioSource.PlayOneShot(cauda);
                        break;
                    case "Corpo":
                        audioSource.PlayOneShot(corpo);
                        break;
                    case "Pancreas":
                        audioSource.PlayOneShot(pancreas);
                        break;
                    case "VeiaCava":
                        audioSource.PlayOneShot(veiacava);
                        break;
                    case "Vesicula":
                        audioSource.PlayOneShot(vesicula);
                        break;
                }
            }
        }
    }
}
