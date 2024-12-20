using System.Collections;
using UnityEngine;

public class AlimentarGato : MonoBehaviour
{
    public Animator animator; // Referencia al Animator del gato
    public int comidaActual = 20; // Nivel actual de comida
    public int comidaMaxima = 100; // Nivel máximo de comida
    public float duracionAnimacion = 55f; // Duración de la animación de comer

    // Método para alimentar al gato
    public void Alimentar()
    {
        if (comidaActual < comidaMaxima)
        {
            comidaActual = comidaActual + 20;
            Debug.Log("Gato alimentado. Comida actual: " + comidaActual);

            // Activa la animación de comer
            animator.SetBool("comiendo", true);

            // Detiene la animación después de un tiempo
            StartCoroutine(DetenerAnimacionComiendo());
        }
        else
        {
            Debug.Log("El gato está lleno y no puede comer más.");
        }
    }

    // Corrutina para detener la animación de comer después de la duración especificada
    private IEnumerator DetenerAnimacionComiendo()
    {
        yield return new WaitForSeconds(duracionAnimacion);

        // Detiene la animación de comer
        animator.SetBool("comiendo", false);
    }
}
