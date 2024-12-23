using System.IO;
using UnityEngine;

[System.Serializable]
public class GatoData
{
    public float comida;
    public float agua;
    public float energia;
    public float felicidad;
    public float suciedad;
    public float salud;
    public float baño;
    public string ultimaHora; // Para guardar la última hora de juego
}

public class SistemaGuardado : MonoBehaviour
{
    private string rutaArchivo;

    private void Awake()
    {
        rutaArchivo = Application.persistentDataPath + "/gatoData.json";
    }

    public void GuardarDatos(GatoStats gatoStats)
    {
        GatoData data = new GatoData
        {
            comida = gatoStats.comida,
            agua = gatoStats.agua,
            energia = gatoStats.energia,
            felicidad = gatoStats.felicidad,
            suciedad = gatoStats.suciedad,
            salud = gatoStats.salud,
            baño = gatoStats.baño,
            ultimaHora = System.DateTime.Now.ToString() // Actualiza la hora al guardar
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(rutaArchivo, json);
        Debug.Log("Datos guardados en: " + rutaArchivo);
    }

    public void CargarDatos(GatoStats gatoStats)
    {
        if (File.Exists(rutaArchivo))
        {
            string json = File.ReadAllText(rutaArchivo);
            GatoData data = JsonUtility.FromJson<GatoData>(json);

            // Asignar los datos al gato
            gatoStats.SetComida(data.comida);
            gatoStats.SetAgua(data.agua);
            gatoStats.SetEnergia(data.energia);
            gatoStats.SetFelicidad(data.felicidad);
            gatoStats.SetSuciedad(data.suciedad);
            gatoStats.SetSalud(data.salud);
            gatoStats.SetBaño(data.baño);
            gatoStats.SetUltimaHora(data.ultimaHora); // Asegúrate de que esta propiedad se cargue correctamente

            Debug.Log("Datos cargados desde: " + rutaArchivo);
        }
        else
        {
            // Si no se encuentra el archivo, crear uno con los valores iniciales
            Debug.LogWarning("No se encontró un archivo de guardado en: " + rutaArchivo);
            CrearNuevoArchivo(gatoStats);  // Crear el archivo con datos predeterminados
        }
    }

    private void CrearNuevoArchivo(GatoStats gatoStats)
    {
        // Crear un archivo nuevo con valores iniciales
        GatoData data = new GatoData
        {
            comida = 100f,
            agua = 100f,
            energia = 100f,
            felicidad = 100f,
            suciedad = 0f,
            salud = 100f,
            baño = 0f,
            ultimaHora = System.DateTime.Now.ToString() // Hora actual como inicial
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(rutaArchivo, json);
        Debug.Log("Nuevo archivo de guardado creado en: " + rutaArchivo);
    }
}
