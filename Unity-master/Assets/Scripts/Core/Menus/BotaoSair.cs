using UnityEngine;

public class BotaoSair : MonoBehaviour
{
    public void QuitGame()
    {
        // Fecha o jogo
        Application.Quit();

        // Mensagem útil para testes no editor (não fecha o editor)
        Debug.Log("Jogo encerrado!"); 
    }
}
