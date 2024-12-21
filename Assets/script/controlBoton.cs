using System.Collections;
using UnityEngine;

public class BotonControl : MonoBehaviour
{
    public GatoStats gatoStats; // Referencia al script de GatoStats
    public Animator gatoAnimator; // Referencia al Animator del gato

    // Alimentar al gato +felicidad +camida 
    public void Alimentar()
    {
        gatoStats.AumentarComida(); // Actualiza el nivel de comida
        gatoAnimator.SetTrigger("comiendo"); // Reproduce la animación de "comer"
        
        
        StartCoroutine(DetenerAnimacionComiendo());
    }

    private IEnumerator DetenerAnimacionComiendo()
    {
        yield return new WaitForSeconds(0.55f);

        // Detiene la animación de comer
        gatoAnimator.SetBool("comiendo", false);
    }

    // Dar agua al gato  -sed +-energia
    public void DarAgua()
    {
        gatoStats.AumentarAgua(); // Actualiza el nivel de agua
        //gatoAnimator.SetTrigger("bebiendo"); // Reproduce la animación de "beber"
    }

    // Dejar al gato dormir +energia +hambre sed
    public void DejarDormir()
    {
        gatoStats.AumentarEnergia(); // Aumenta la energía
        //gatoAnimator.SetTrigger("durmiendo"); // Reproduce la animación de "dormir"
    }

    // Jugar con el gato -energia
    public void Jugar()
    {
        gatoStats.AumentarFelicidad(); // Aumenta felicidad
        gatoStats.ReducirEnergia();   // Reduce energía
        //gatoAnimator.SetTrigger("jugando"); // Reproduce la animación de "jugar"
    }

    // Bañar al gato -suciedad
    public void Bañar()
    {
        gatoStats.ResetearSuciedad();  // Limpia al gato
        //gatoAnimator.SetTrigger("bañarse"); // Reproduce la animación de "bañarse"
    }

    // Dar mimos al gato +felicidad
    public void Mimar()
    {
        gatoStats.AumentarFelicidad(); // Aumenta felicidad
        //gatoAnimator.SetTrigger("caricias"); // Reproduce la animación de "caricias"
    }

    // Curar al gato +salud +- energia +-felicidad +-comida +-suciedad
    public void Curar()
    {
        gatoStats.Curar(); // Restaura la salud
        //gatoAnimator.SetTrigger("curandose"); // Reproduce la animación de "curarse"
    }

    // Explorar con el gato +felicidad -energia +hambre +sed
    public void Explorar()
    {
        gatoStats.ReducirEnergia();   // Reduce energía
        gatoStats.AumentarSuciedad(); // Aumenta suciedad
        //gatoAnimator.SetTrigger("explorando"); // Reproduce la animación de "explorar"
    }

    //La mascota hace sus necesidades -baño +felicidad -energia
    public void irAlBaño(){
        
    }

}
