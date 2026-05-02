using UnityEngine;
using UnityEngine.SceneManagement; // Obligatorio para recargar el nivel

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el jugador choca con un objeto que tiene el Tag "Enemigo"
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            // Reinicia la escena actual instantáneamente desde cero
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}