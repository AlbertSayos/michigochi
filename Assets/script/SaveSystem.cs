using UnityEngine;

public class SaveSystem : MonoBehaviour {
    public CatInteraction catInteraction;

    void Start() {
        // Cargar felicidad al iniciar
        if (PlayerPrefs.HasKey("Happiness")) {
            int savedHappiness = PlayerPrefs.GetInt("Happiness");
            catInteraction.happiness = savedHappiness;
        }
    }

    void OnApplicationQuit() {
        // Guardar felicidad al cerrar
        PlayerPrefs.SetInt("Happiness", catInteraction.happiness);
    }
}
