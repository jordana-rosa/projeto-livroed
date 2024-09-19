using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarScene : MonoBehaviour
{
    public void MudarDeCena(string nomeDaCena)
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}