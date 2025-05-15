using UnityEngine;
using UnityEngine.UI;
using Battle;
using UnityEngine.SceneManagement;

namespace Core{

 public class DifficultySelector
 {
     public void SetEasy()
     {
         DifficultyManager.Instance.SetDifficulty(Difficulty.Easy);
    }
     public void SetMedium()
    {
        DifficultyManager.Instance.SetDifficulty(Difficulty.Medium);
        SceneManager.LoadScene("LoadGame"); // Carrega a cena "créditos"
     }

    public void SetHard()
    {
        DifficultyManager.Instance.SetDifficulty(Difficulty.Hard);
        SceneManager.LoadScene("LoadGame"); // Carrega a cena "LoadScene" que começa o jogo
    }
 }

 }
