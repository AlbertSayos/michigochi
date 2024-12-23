using UnityEngine;

public class ParticulasSuciedad : MonoBehaviour
{
    public ParticleSystem sistemaDeParticulas; // Arrastrá aquí tu sistema de partículas en el Inspector
    public GatoStats gatoStats; // Referencia al script de GatoStats

    private ParticleSystem.EmissionModule emisionParticulas;

    private void Start()
    {
        // Obtener el módulo de emisión del sistema de partículas
        emisionParticulas = sistemaDeParticulas.emission;
    }

    private void Update()
    {
        // Igualar el número de partículas emitidas al valor de suciedad
        emisionParticulas.rateOverTime = gatoStats.GetSuciedad(); // Ajustar según el valor actual de suciedad
    }
}
