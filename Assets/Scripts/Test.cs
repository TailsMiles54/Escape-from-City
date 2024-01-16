using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
    [Inject] private Player _player;
    
    void Update()
    {
        _player.Test(Time.deltaTime.ToString());
    }
}