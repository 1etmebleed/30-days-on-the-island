using UnityEngine;

public class TransparencyController : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color originalColor;
    public Color transparentColor = new Color(1, 1, 1, 0.5f); // Полупрозрачный цвет

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        // Проверяем, есть ли Renderer
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }
        else
        {
            Debug.LogError("No Renderer found on " + gameObject.name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && objectRenderer != null) // Проверяем наличие Renderer
        {
            objectRenderer.material.shader = Shader.Find("Custom/TransparentShader");
            objectRenderer.material.color = transparentColor;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && objectRenderer != null) // Проверяем наличие Renderer
        {
            objectRenderer.material.shader = Shader.Find("Standard");
            objectRenderer.material.color = originalColor;
        }
    }
}