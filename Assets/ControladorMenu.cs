using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour
{
    // Función para el botón REINICIAR
    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Función para el botón SALIR
    public void SalirJuego()
    {
        Debug.Log("Cerrando la aplicación...");
        Application.Quit();
    }
}