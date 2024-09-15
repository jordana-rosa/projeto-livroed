using UnityEngine;

public class PlaySoundOnClickArea : MonoBehaviour
{
    public AudioClip Baco, Cabeca, Cauda, Corpo, Pancreas, Veiacava, Vesicula;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing from this GameObject.");
        }
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
                Debug.Log("Clicked object: " + clickedObject); // Mensagem de depuração

                switch (clickedObject)
                {
                    case "GameObjects - Baco":
                        audioSource.PlayOneShot(Baco);
                        break;
                    case "GameObjects - Cabeca":
                        audioSource.PlayOneShot(Cabeca);
                        break;
                    case "GameObjects - Cauda":
                        audioSource.PlayOneShot(Cauda);
                        break;
                    case "GameObjects - Corpo":
                        audioSource.PlayOneShot(Corpo);
                        break;
                    case "GameObjects - Pancreas":
                        audioSource.PlayOneShot(Pancreas);
                        break;
                    case "GameObjects - VeiaCava":
                        audioSource.PlayOneShot(Veiacava);
                        break;
                    case "GameObjects - Vesicula":
                        audioSource.PlayOneShot(Vesicula);
                        break;
                    default:
                        Debug.LogWarning("No matching case for clicked object.");
                        break;
                }
            }
            else
            {
                Debug.LogWarning("No collider hit.");
            }
        }
        else
        {
            Debug.LogWarning("Raycast did not hit anything.");
        }
    }
}
