using UnityEngine;

public class TransparencyController : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color originalColor;
    public Color transparentColor = new Color(1, 1, 1, 0.5f); // �������������� ����

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        // ���������, ���� �� Renderer
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
        if (other.CompareTag("Player") && objectRenderer != null) // ��������� ������� Renderer
        {
            objectRenderer.material.shader = Shader.Find("Custom/TransparentShader");
            objectRenderer.material.color = transparentColor;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && objectRenderer != null) // ��������� ������� Renderer
        {
            objectRenderer.material.shader = Shader.Find("Standard");
            objectRenderer.material.color = originalColor;
        }
    }
}