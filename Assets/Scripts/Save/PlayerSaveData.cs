using System;
using System.Collections.Generic;

[Serializable]
public class PlayerSaveData
{
    public string Name = "Started Nickname";
    public int Level = 1;
    public int Exp = 0;
    public List<Skill> Skills = new List<Skill>();
    public List<Parameter> Parameters = new List<Parameter>();
    public Inventory Inventory = new Inventory();
}