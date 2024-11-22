using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    public TextMeshProUGUI timeText; // Referência ao campo de texto
    private float elapsedTime = 0f;

    void Start()
    {
        if (timeText == null)
        {
            Debug.LogError("O campo de texto não foi atribuído!");
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        // Converte o tempo em minutos e segundos
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        // Atualiza o texto com o formato desejado
        timeText.text = $"Time: {minutes:00}:{seconds:00}";
    }
}
