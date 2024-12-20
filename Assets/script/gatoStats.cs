using UnityEngine;

public class GatoStats : MonoBehaviour
{
    // Stats principales del gato
    public float comida = 50f;
    public float agua = 50f;
    public float energia = 50f;
    public float felicidad = 50f;
    public float suciedad = 0f;
    public float salud = 90f;

    // Valores de incremento/decremento
    private float comidaAumento = 20f;
    private float aguaAumento = 20f;
    private float energiaAumento = 10f;
    private float felicidadAumento = 15f;
    private float energiaReduccion = 10f;
    private float suciedadAumento = 10f;
    private float saludAumento = 20f;
    private float saludReduccionPorCritico = 5f;

    // Stats principales del gato
    public float comidaMax = 100f;
    public float aguaMax = 100f;
    public float energiaMax = 100f;
    public float felicidadMax = 100f;
    public float suciedadMax = 100f;
    public float saludMax = 100f;

    // Métodos para modificar stats
    public void AumentarComida()
    {
        comida = Mathf.Clamp(comida + comidaAumento, 0, 100);
    }

    public void AumentarAgua()
    {
        agua = Mathf.Clamp(agua + aguaAumento, 0, 100);
    }

    public void AumentarEnergia()
    {
        energia = Mathf.Clamp(energia + energiaAumento, 0, 100);
    }

    public void ReducirEnergia()
    {
        energia = Mathf.Clamp(energia - energiaReduccion, 0, 100);
    }

    public void AumentarFelicidad()
    {
        felicidad = Mathf.Clamp(felicidad + felicidadAumento, 0, 100);
    }

    public void ResetearSuciedad()
    {
        suciedad = 0;
    }

    public void AumentarSuciedad()
    {
        suciedad = Mathf.Clamp(suciedad + suciedadAumento, 0, 100);
    }

    public void Curar()
    {
        salud = Mathf.Clamp(salud + saludAumento, 0, 100);
    }

    // Método para aplicar penalización si un stat crítico está en 0
    public void VerificarCriticos()
    {
        if (comida <= 0 || agua <= 0 || suciedad >= 100)
        {
            ReducirSaludPorCritico();
        }
    }

    private void ReducirSaludPorCritico()
    {
        salud = Mathf.Clamp(salud - saludReduccionPorCritico, 0, 100);
    }

    // Método de actualización para disminuir valores con el tiempo
    private void Update()
    {
        // Lógica de decremento gradual
        comida = Mathf.Clamp(comida - Time.deltaTime, 0, 100);
        agua = Mathf.Clamp(agua - Time.deltaTime, 0, 100);
        energia = Mathf.Clamp(energia - (Time.deltaTime * 0.5f), 0, 100);
        
        // Verificar estados críticos
        VerificarCriticos();
    }
}
