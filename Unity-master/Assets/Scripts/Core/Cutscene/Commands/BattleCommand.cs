using System.Collections;
using UnityEngine;

namespace Core
{
   [System.Serializable]
public class BattleCommand : ICutsceneCommand
{
    [SerializeField] private int battleID; // ID do grupo de inimigos
    
    public bool IsFinished { get; set; }

    public IEnumerator Co_Execute()
    {       
        // Carrega cena de batalha
        SceneLoader.LoadBattleScene();
        
        IsFinished = true;
        yield break;
    }
}
}