using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string Name;
    
    private int Level;
    private int Exp;
    
    private List<Skill> _skills;
    private List<Parameter> _parameters;
    private List<Item> _items;
    
    public void Test(string text)
    {
        Debug.Log(text);
    }
}