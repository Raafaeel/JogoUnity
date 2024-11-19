using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public interface IInteractable
    {
        Cutscene Interaction { get; }
        void Interact();
    }
}
