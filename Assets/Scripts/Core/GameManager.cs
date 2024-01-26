using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] private Player _player;
    
    void Start()
    {
        _player.SetupFromSave();
    }
}
