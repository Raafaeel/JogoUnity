// Assets/Scripts/Core/UI/MainMenu/DifficultySelector.cs
using UnityEngine;
using Battle;
using Core;

public class DifficultySelector : MonoBehaviour
{
    public void SelectEasy() => DifficultyManager.Instance.SetDifficultyAndLoad(Difficulty.Easy);
    public void SelectMedium() => DifficultyManager.Instance.SetDifficultyAndLoad(Difficulty.Medium);
    public void SelectHard() => DifficultyManager.Instance.SetDifficultyAndLoad(Difficulty.Hard);
}