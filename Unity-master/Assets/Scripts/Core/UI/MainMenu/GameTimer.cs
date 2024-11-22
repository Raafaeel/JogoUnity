using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Variáveis para controlar o tempo
    private float elapsedTime = 0f; // Tempo decorrido
    private bool isRunning = false; // Indica se o contador está ativo

    // Referência opcional para exibir o tempo em uma UI de texto
    public Text timerText;

    void Update()
    {
        // Atualiza o tempo apenas se o contador estiver ativo
        if (isRunning)
        {
            elapsedTime += Time.deltaTime; // Incrementa o tempo decorrido
            UpdateTimerDisplay(); // Atualiza o texto da UI
        }
    }

    // Inicia o contador
    public void StartTimer()
    {
        isRunning = true;
    }

    // Para o contador
    public void StopTimer()
    {
        isRunning = false;
    }

    // Reinicia o contador
    public void ResetTimer()
    {
        elapsedTime = 0f;
        UpdateTimerDisplay();
    }

    // Formata o tempo decorrido como texto
    private void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            // Converte o tempo para o formato MM:SS
            int minutes = Mathf.FloorToInt(elapsedTime / 60F);
            int seconds = Mathf.FloorToInt(elapsedTime % 60F);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
