using UnityEngine;

public class PlaySoundOnClickArea : MonoBehaviour
{
    public AudioClip Baco, Cabeca, Cauda, Corpo, Pancreas, VeiaCava, Vesicula;
    private AudioSource globalAudioSource;

    void Start()
    {
        globalAudioSource = GetComponent<AudioSource>();
        if (globalAudioSource == null)
        {
            Debug.LogError("AudioSource component is missing from this GameObject.");
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Tela tocada!"); // Adicionando log para verificar se o toque é detectado
                HandleInput(touch.position);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse clicado!"); // Adicionando log para detectar cliques no mouse
            HandleInput(Input.mousePosition);
        }
    }

    void HandleInput(Vector3 inputPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                Debug.Log("Objeto clicado: " + hit.collider.gameObject.name); // Verifica qual objeto foi clicado
                globalAudioSource.Stop();
                PlayAudioForObject(hit.collider.gameObject.name);
            }
        }
        else
        {
            Debug.LogWarning("Nenhum objeto foi clicado.");
        }
    }

    void PlayAudioForObject(string objectName)
    {
        switch (objectName)
        {
            case "Baco":
                globalAudioSource.PlayOneShot(Baco);
                break;
            case "Cabeca":
                globalAudioSource.PlayOneShot(Cabeca);
                break;
            case "Cauda":
                globalAudioSource.PlayOneShot(Cauda);
                break;
            case "Corpo":
                globalAudioSource.PlayOneShot(Corpo);
                break;
            case "Pancreas":
                globalAudioSource.PlayOneShot(Pancreas);
                break;
            case "VeiaCava":
                globalAudioSource.PlayOneShot(VeiaCava);
                break;
            case "Vesicula":
                globalAudioSource.PlayOneShot(Vesicula);
                break;
            default:
                Debug.LogWarning("Nenhum áudio associado ao objeto clicado: " + objectName);
                break;
        }
    }
}
