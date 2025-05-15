using UnityEngine;

public class PlayerHealthRenderer : MonoBehaviour
{
    [SerializeField]
    private RectTransform thisRect;
    private float maxWidth;

    [SerializeField]
    private RectTransform healthBar;

    private void OnEnable()
    {
        Player.HealthUpdated += UpdateHealthbar;
    }

    private void OnDisable()
    {
        Player.HealthUpdated -= UpdateHealthbar;
    }

    private void Start()
    {
        maxWidth = thisRect.sizeDelta.x;
    }

    public void UpdateHealthbar(float currentHealth, float maxHealth)
    {
        float healthbarWidth = Utility.Remap(currentHealth, 0, maxHealth, 0, maxWidth);
        healthBar.sizeDelta = new Vector2(healthbarWidth, healthBar.sizeDelta.y);
    }
}

public class Utility
{
    public static float Remap(float value, float minOld, float maxOld, float newOld, float newMax)
    {
        return (value - minOld) / (maxOld - minOld) * (newMax - newOld) + newOld;
    }
}