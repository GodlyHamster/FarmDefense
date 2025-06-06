using TMPro;
using UnityEngine;

public class WaveUIRenderer : MonoBehaviour
{
    [SerializeField]
    private WaveSpawner waveSpawner;

    [SerializeField]
    private TextMeshProUGUI waveNumberText;

    private void OnEnable()
    {
        waveSpawner.OnWaveUpdated += WaveSpawner_OnWaveUpdated;
    }

    private void OnDisable()
    {
        waveSpawner.OnWaveUpdated -= WaveSpawner_OnWaveUpdated;
    }

    private void WaveSpawner_OnWaveUpdated(int waveNumber)
    {
        waveNumberText.text = $"Current wave: {waveNumber + 1}";
    }
}
