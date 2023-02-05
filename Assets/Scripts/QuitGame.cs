using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Salir());
    }

    IEnumerator Salir()
    {
        yield return new WaitForSeconds(5.0f);
        Application.Quit();
    }

}
