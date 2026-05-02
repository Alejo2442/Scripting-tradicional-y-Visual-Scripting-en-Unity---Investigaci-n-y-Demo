using UnityEngine;

public class PararMusica2 : MonoBehaviour
{
    public AudioSource laMusica;

    // OnEnable se ejecuta automáticamente en el instante en que el objeto se enciende/aparece
    void OnEnable()
    {
        laMusica.Stop();
    }
}