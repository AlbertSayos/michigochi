using UnityEngine;
using System;

public class GatoStats : MonoBehaviour
{
    // Stats principales del gato
    public float comida = 50f; //hambre - 
    public float agua = 50f; //sed - 
    public float energia = 50f; //descansar +, jugar- 
    public float felicidad = 50f; //
    public float suciedad = 0f;
    public float salud = 90f;
    public float baño = 20f;

    // Valores de incremento/decremento
    private float comidaAumento = 15f;
    private float aguaAumento = 5f;
    private float energiaAumento = 5f;
    private float felicidadAumento = 5f;
    private float energiaReduccion = 5f;
    private float suciedadAumento = 5f;
    private float saludAumento = 5f;
    private float saludReduccionPorCritico = 5f;
    private float comidaReduccion = 5f;
    private float aguaReduccion = 5f;
    private float bañoReduccion = 5f;

    // Para almacenar la última hora
    private string ultimaHora = ""; // Guardará la última hora de juego

    private void Start()
    {
        // Si no hay una hora guardada en el sistema, se actualiza con la hora actual
        if (string.IsNullOrEmpty(ultimaHora))
        {
            ultimaHora = DateTime.Now.ToString(); // Asigna la hora actual si no hay una guardada
        }
    }


    // Métodos para modificar stats
    public bool Alimentar()
    {
        if (comida > 0 && comida < 100)
        {
            AumentarComida();
            AumentarFelicidad();
            // Actualizar la hora cada vez que alimentamos al gato
            ultimaHora = DateTime.Now.ToString();
            return true;
        }
        else
        {
            reducirFelicidad();
            return false;
        }
    }

    // Métodos para modificar stats
    public void AumentarComida()
    {
        comida = Mathf.Clamp(comida + comidaAumento, 0, 100);
    }

    public void reducirComida()
    {
        comida = Mathf.Clamp(comida - comidaReduccion, 0, 100);
    }

    public void AumentarAgua()
    {
        agua = Mathf.Clamp(agua + aguaReduccion, 0, 100);
    }

    public void reducirAgua()
    {
        agua = Mathf.Clamp(agua - aguaAumento, 0, 100);
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

    public void reducirFelicidad()
    {
        felicidad = Mathf.Clamp(felicidad - felicidadAumento, 0, 100);
    }

    public void ResetearSuciedad()
    {
        suciedad = 0;
    }

    public void AumentarSuciedad()
    {
        suciedad = Mathf.Clamp(suciedad + suciedadAumento, 0, 100);
    }

    public void aumentarBaño()
    {
        suciedad = Mathf.Clamp(baño + bañoReduccion, 0, 100);
    }

    public void reducirBaño()
    {
        suciedad = Mathf.Clamp(0, 0, 100);
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
        // Verificar estados críticos
        VerificarCriticos();
    }

    // Métodos para obtener los valores actuales
    public float GetComida()
    {
        return comida;
    }

    public float GetAgua()
    {
        return agua;
    }

    public float GetEnergia()
    {
        return energia;
    }

    public float GetFelicidad()
    {
        return felicidad;
    }

    public float GetSuciedad()
    {
        return suciedad;
    }

    public float GetSalud()
    {
        return salud;
    }

    public float GetBaño()
    {
        return baño;
    }

    // Método para obtener la última hora
    public string GetUltimaHora()
    {
        return ultimaHora;
    }

    // Método para establecer la última hora
    public void SetUltimaHora(string nuevaHora)
    {
        ultimaHora = nuevaHora;
    }

    public void SetComida(float nuevaComida)
    {
        comida = nuevaComida;
    }

    public void SetAgua(float nuevaAgua)
    {
        agua = nuevaAgua;
    }

    public void SetEnergia(float nuevaEnergia)
    {
        energia = nuevaEnergia;
    }

    public void SetFelicidad(float nuevaFelicidad)
    {
        felicidad = nuevaFelicidad;
    }

    public void SetSuciedad(float nuevaSuciedad)
    {
        suciedad = nuevaSuciedad;
    }

    public void SetSalud(float nuevaSalud)
    {
        salud = nuevaSalud;
    }

    public void SetBaño(float nuevoBaño)
    {
        baño = nuevoBaño;
    }

}
