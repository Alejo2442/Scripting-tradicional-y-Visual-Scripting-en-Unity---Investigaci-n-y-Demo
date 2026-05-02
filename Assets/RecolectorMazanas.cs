using UnityEngine;

public class RecolectorManzanas : MonoBehaviour
{
    private int manzanasRecogidas = 0;
    public int totalManzanas = 4;

    // Esta variable nos permitirá conectar el panel de victoria desde el editor
    public GameObject pantallaVictoria;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Manzana"))
        {
            manzanasRecogidas++;
            Destroy(collision.gameObject);

            Debug.Log("Manzanas recogidas: " + manzanasRecogidas);

            if (manzanasRecogidas >= totalManzanas)
            {
                GanarJuego();
            }
        }
    }

    private void GanarJuego()
    {
        // 1. Activamos la pantalla de victoria para que se vea
        if (pantallaVictoria != null)
        {
            pantallaVictoria.SetActive(true);
        }

        // 2. Detenemos el tiempo del juego para que el personaje y los enemigos dejen de moverse
        Time.timeScale = 0f;

        Debug.Log("Juego Terminado. ¡Ganaste!");
    }
}