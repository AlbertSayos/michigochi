using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotonControl : MonoBehaviour
{
    public GatoStats gatoStats; // Referencia al script de GatoStats
    public Animator gatoAnimator; // Referencia al Animator del gato
    public GameObject eventSystem; 

    // Alimentar al gato +felicidad +comida 
    public void Alimentar()
    {
        // gatoStats.AumentarComida(); // Actualiza el nivel de comida
        // gatoStats.AumentarFelicidad();

        bool felicidadActual = gatoStats.Alimentar();

        gatoAnimator.SetTrigger(felicidadActual ? "comiendo" : "rechazo"); // Reproduce la animación de "comer"
        
        StartCoroutine(DetenerAnimacion(felicidadActual ? "comiendo" : "rechazo", 2.1f));
    }

    // Dar agua al gato -sed +-energia
    public void DarAgua()
    {
        gatoStats.AumentarAgua(); // Actualiza el nivel de agua
        gatoStats.ReducirEnergia();
        gatoAnimator.SetTrigger("bebiendo"); // Reproduce la animación de "beber"
        
        StartCoroutine(DetenerAnimacion("bebiendo", 2.1f));
    }

    // Dejar al gato dormir +energia (+hambre +sed = se va a reducir por tiempo)
    public void DejarDormir()
    {
        gatoStats.AumentarEnergia(); // Aumenta la energía
        gatoAnimator.SetTrigger("durmiendo"); // Reproduce la animación de "dormir"
        
        StartCoroutine(DetenerAnimacion("durmiendo", 2.1f));
    }

    // Jugar con el gato -energia
    public void Jugar()
    {
        gatoStats.AumentarFelicidad(); // Aumenta felicidad
        gatoStats.ReducirEnergia();   // Reduce energía
        gatoAnimator.SetTrigger("jugando"); // Reproduce la animación de "jugar"
        
        StartCoroutine(DetenerAnimacion("jugando", 2.1f));
    }

    // Bañar al gato -suciedad
    public void Bañar()
    {
        gatoStats.ResetearSuciedad();  // Limpia al gato
        gatoAnimator.SetTrigger("bañarse"); // Reproduce la animación de "bañarse"
        
        StartCoroutine(DetenerAnimacion("bañarse", 2.1f));
    }

    // Dar mimos al gato +felicidad
    public void Mimar()
    {
        gatoStats.AumentarFelicidad(); // Aumenta felicidad
        gatoAnimator.SetTrigger("caricias"); // Reproduce la animación de "caricias"
        
        StartCoroutine(DetenerAnimacion("caricias", 2.1f));
    }

    // Curar al gato +salud +-energia +-felicidad +-comida +-suciedad
    public void Curar()
    {
        gatoStats.Curar(); // Restaura la salud
        gatoAnimator.SetTrigger("curandose"); // Reproduce la animación de "curarse"
        
        StartCoroutine(DetenerAnimacion("curandose", 2.1f));
    }

    // Explorar con el gato +felicidad -energia +hambre +sed
    public void Explorar()
    {
        gatoStats.ReducirEnergia();   // Reduce energía
        gatoStats.AumentarSuciedad(); // Aumenta suciedad
        gatoStats.reducirAgua();
        gatoStats.reducirComida();
        gatoAnimator.SetTrigger("explorando"); // Reproduce la animación de "explorar"
        
        StartCoroutine(DetenerAnimacion("explorando", 2.1f));
    }

    // La mascota hace sus necesidades -baño +felicidad -energia
    public void IrAlBaño()
    {
        gatoStats.AumentarFelicidad(); // Aumenta felicidad
        gatoStats.ReducirEnergia();   // Reduce energía
        gatoStats.AumentarFelicidad();
        //gatoAnimator.SetTrigger("irAlBaño"); // Reproduce la animación de "ir al baño"
        
        //StartCoroutine(DetenerAnimacion("irAlBaño", 1.0f));
    }

    // Método genérico para detener animaciones después de un tiempo
    private IEnumerator DetenerAnimacion(string triggerName, float delay)
    {
        eventSystem.SetActive(false);
        yield return new WaitForSeconds(delay);
        Debug.Log("detuve: " + triggerName);
        gatoAnimator.SetBool(triggerName, false); // Detiene la animación correspondiente
        eventSystem.SetActive(true);
    }
}
