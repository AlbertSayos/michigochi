using UnityEngine;
using UnityEngine.UI;
using TMPro; // Para usar TextMeshPro

public class ControlDeBarras : MonoBehaviour
{
    // Referencia al script GatoStats
    
    public GatoStats gatoStats;

    // Referencias a los elementos de la UI
    public TextMeshProUGUI textoComida;

    public TextMeshProUGUI textoAgua;

    public TextMeshProUGUI textoEnergia;

    public TextMeshProUGUI textoBaño;

    public TextMeshProUGUI textoSalud;

    public TextMeshProUGUI textoFelicidad;

    private void Update()
    {
        // Sincronizar la barra de comida y su texto
        textoComida.text = $"{gatoStats.GetComida()}";

        // Sincronizar la barra de agua y su texto
        textoAgua.text = $"{gatoStats.GetAgua()}";

        // Sincronizar la barra de energía y su texto
        textoEnergia.text = $"{gatoStats.GetEnergia()}";

        // Sincronizar la barra de suciedad y su texto
        textoBaño.text = $"{gatoStats.GetBaño()}";

        textoFelicidad.text = $"{gatoStats.GetFelicidad()}";

        textoSalud.text = $"{gatoStats.GetSalud()}";
    }
}
