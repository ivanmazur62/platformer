using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorldObject : MonoBehaviour
{
    void Update()
    {
        if(GameController.Instance.IsPause) return;
        
        LocalUpdate();
    }

    protected abstract void LocalUpdate();
}
