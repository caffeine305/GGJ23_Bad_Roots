using UnityEngine;

public class Billboarding : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(37.0f,Camera.main.transform.eulerAngles.y,0f); //el 37 es para que cheque con la orientación de la cámara.
    }
}
