using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class GameCard : MonoBehaviour
{
    private static readonly int Color1 = Shader.PropertyToID("_COLOR");
    private static readonly int Texture1 = Shader.PropertyToID("_TEXTURE");
    private static readonly int IsHolografic = Shader.PropertyToID("_IS_HOLOGRAPHIC");
    
    [Header("Card Data")]
    [SerializeField] private GameCardSO _data;

    [Header("References")]
    [SerializeField] private TextMeshPro _titleTxt;
    [SerializeField] private TextMeshPro _levelTxt;
    [SerializeField] private TextMeshPro _typeTxt;
    [SerializeField] private TextMeshPro _descriptionTxt;
    [SerializeField] private TextMeshPro _statsTxt;

    private MaterialPropertyBlock _propertyBlock;

    private void Start()
    {
        _propertyBlock = new MaterialPropertyBlock();
        
        InitData();
    }

    [ContextMenu("Update Data")]
    private void InitData()
    {
        _titleTxt.text = _data.title;
        _levelTxt.text = _data.GetLevel();
        _typeTxt.text = $"[{_data.GetCardType()}]";
        _descriptionTxt.text = _data.description;
        _statsTxt.text = $"ATK/{_data.statAttack}   DEF/{_data.statDefense}";
        
        _propertyBlock.SetColor(Color1, _data.color);
        _propertyBlock.SetTexture(Texture1, _data.texture);
        _propertyBlock.SetFloat(IsHolografic, _data.isHolografic? 1: 0);
        
        GetComponent<Renderer>().SetPropertyBlock(_propertyBlock);
    }
    
}
