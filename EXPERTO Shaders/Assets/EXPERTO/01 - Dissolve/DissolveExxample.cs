using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveExxample : MonoBehaviour
{
    private static readonly int Dissolve = Shader.PropertyToID("_DISSOLVE");
    
    [Header("Dissolve")]
    [SerializeField] private float _dissolveSpeed = 1;
    [SerializeField] float _dissolveWait;
    [Space]
    [SerializeField] private bool _useIndex;
    [SerializeField] private MeshRenderer _dissolveMesh;
    [SerializeField] private int _dissolveMeshIndex;
    
    [Header("References")]
    [SerializeField] private Material _dissolveMaterial;

    private bool _isDissolving = false;

    private float _dissolveValue;
    private float _valueStart = 1;
    private float _valueEnd = 0;

    private void Start()
    {
        if (_useIndex)
        {
            _dissolveMaterial = _dissolveMesh.materials[_dissolveMeshIndex];
        }
        _dissolveMaterial.SetFloat(Dissolve, _valueStart);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & !_isDissolving)
        {
            StartCoroutine(MakeDissolve());
        }
    }

    private IEnumerator MakeDissolve()
    {
        _isDissolving = true;
        
        _dissolveValue = _valueStart;
        while (_dissolveValue > _valueEnd)
        {
            _dissolveValue -= Time.deltaTime * _dissolveSpeed;
            _dissolveMaterial.SetFloat(Dissolve, _dissolveValue);
            yield return null;
        }

        _dissolveValue = _valueEnd;
        Debug.Log($"<color=green><b>CHANGE!</b></color>");
        yield return new WaitForSeconds(_dissolveWait);
        
        while (_dissolveValue < _valueStart)
        {
            _dissolveValue += Time.deltaTime * _dissolveSpeed;
            _dissolveMaterial.SetFloat(Dissolve, _dissolveValue);
            yield return null;
        }
        _dissolveValue = _valueStart;
        
        _isDissolving = false;
    }
}
