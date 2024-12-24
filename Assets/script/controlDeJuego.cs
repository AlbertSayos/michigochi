using UnityEngine;
using System;

public class ControlDeJuego : MonoBehaviour
{
    public GatoStats gatoStats; // Referencia al script de stats
    public SistemaGuardado sistemaGuardado; // Referencia al sistema de guardado
    private DateTime ultimaActualizacion; // Última hora guardada
    private float tiempoGuardado = 0f; // Contador para el guardado automático
    public float intervaloGuardado = 60f; // 1 minuto en segundos

    private void Start()
    {
        // Verificar si el sistema de guardado está asignado
        if (sistemaGuardado == null)
        {
            Debug.LogError("Sistema de guardado no asignado en el inspector.");
            return;
        }

        // Intentar cargar datos al iniciar el juego
        sistemaGuardado.CargarDatos(gatoStats);
        ActualizarStatsPorTiempo();
    }

    private void Update()
    {
        // Incrementar el contador de tiempo para el guardado automático
        tiempoGuardado += Time.deltaTime;

        // Si ha pasado 1 minuto, guardamos
        if (tiempoGuardado >= intervaloGuardado)
        {
            GuardarEstados();  // Guardamos cada minuto
            tiempoGuardado = 0f; // Reiniciamos el contador
        }
    }

    public void GuardarEstados()
    {
        // Guardar los estados actuales del gato
        sistemaGuardado.GuardarDatos(gatoStats);
        Debug.Log("Datos guardados correctamente.");
    }

    private void ActualizarStatsPorTiempo()
    {
        // Calcular cuánto tiempo ha pasado desde la última actualización
        string ultimaHora = gatoStats.GetUltimaHora();
        if (!string.IsNullOrEmpty(ultimaHora))
        {
            DateTime.TryParse(ultimaHora, out ultimaActualizacion);
        }
        else
        {
            ultimaActualizacion = DateTime.Now;
        }

        TimeSpan diferencia = DateTime.Now - ultimaActualizacion;
        int horasTranscurridas = (int)diferencia.TotalHours;

        // Ajustar los stats según el tiempo transcurrido
        gatoStats.comida = Mathf.Clamp(gatoStats.comida - (horasTranscurridas * 5f), 0, 100);
        gatoStats.agua = Mathf.Clamp(gatoStats.agua - (horasTranscurridas * 5f), 0, 100);
        gatoStats.felicidad = Mathf.Clamp(gatoStats.felicidad - (horasTranscurridas * 5f), 0, 100);
        gatoStats.suciedad = Mathf.Clamp(gatoStats.suciedad + (horasTranscurridas * 5f), 0, 100);
    }

    // Guardar datos cuando el juego se cierra
    private void OnApplicationQuit()
    {
        GuardarEstados(); // Guarda los datos antes de salir
        Debug.Log("Datos guardados al cerrar la aplicación.");
    }

    private void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
        {
            GuardarEstados(); // Guarda los datos cuando la app se pausa
            Debug.Log("Datos guardados al pausar la aplicación.");
        }
    }
}
