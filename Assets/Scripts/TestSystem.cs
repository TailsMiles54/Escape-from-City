using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TestSystem : MonoBehaviour
{
    [Inject] private Player _player;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                _player.ChangeNickname("BlackTails");
            }
        }
    }
}