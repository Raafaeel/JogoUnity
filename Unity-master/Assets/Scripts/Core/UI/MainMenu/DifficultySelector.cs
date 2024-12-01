using UnityEngine;
using UnityEngine.UI;
using Battle;
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
     }

    public void SetHard()
    {
        DifficultyManager.Instance.SetDifficulty(Difficulty.Hard);
    }
 }

 }
