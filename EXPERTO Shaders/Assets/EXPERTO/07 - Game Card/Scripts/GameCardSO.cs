using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public enum GameCardType
{
    None, Spellcaster, Dragon, Effect
}

[CreateAssetMenu(fileName="New Game Card", menuName = "ScriptableObject/Game Card", order=1)]
public class GameCardSO : ScriptableObject
{
    [Header("Information")]
    public string title;
    [Range (0,12)] public int level;
    public GameCardType[] types;
    [TextArea] public string description;
    
    [Header("Card")]
    public Texture texture;
    public Color color;
    public bool isHolografic;
    
    [Header("Stats")]
    public int statAttack;
    public int statDefense;

    private string _levelString = "<sprite index=0>";
    public string GetLevel()
    {
        if(level == 0 ) return String.Empty;

        var tmpLevelBuilder = new StringBuilder();
        tmpLevelBuilder.Append(_levelString);
        
        for (int i = 1; i < level; i++)
        {
            tmpLevelBuilder.Append($" {_levelString}");
        }

        return tmpLevelBuilder.ToString();
    }
    public string GetCardType()
    {
        var tmpType = string.Join('/',types);

        return tmpType;
    }
}
