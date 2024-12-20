using UnityEngine;
using UnityEngine.UI;

public class CatInteraction : MonoBehaviour {
    public Sprite happySprite; // Imagen del gato feliz
    public Sprite normalSprite; // Imagen normal del gato
    public Slider happinessBar; // Barra de felicidad (opcional)

    public int happiness = 50; // Nivel inicial de felicidad (0-100)
    private float smileDuration = 1.5f; // Duración de la sonrisa

    private SpriteRenderer spriteRenderer;
    private bool isSmiling = false;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateHappinessBar();
    }

    void OnMouseDown() {
        if (!isSmiling) {
            happiness += 10; // Incrementar felicidad al interactuar
            happiness = Mathf.Clamp(happiness, 0, 100); // Limitar entre 0-100
            StartCoroutine(Smile());
            UpdateHappinessBar();
            Debug.Log("Mause click");
        }
    }

    private System.Collections.IEnumerator Smile() {
        isSmiling = true;
        spriteRenderer.sprite = happySprite; // Cambiar a imagen feliz
        yield return new WaitForSeconds(smileDuration); // Esperar
        spriteRenderer.sprite = normalSprite; // Volver a imagen normal
        isSmiling = false;
    }

    private void UpdateHappinessBar() {
        if (happinessBar != null) {
            happinessBar.value = happiness / 100f;
        }
    }
}
