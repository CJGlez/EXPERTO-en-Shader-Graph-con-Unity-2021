using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
public class GlitchAnimation : MonoBehaviour
{
    private static readonly int Glitch = Shader.PropertyToID("_USE_GLITCH");
    
    [Header("Settings")]
    [SerializeField] private Vector2 _timeRange;
    [SerializeField] private float _timeWait = .2f;
    
    private Material _material;
    

    private void Start()
    {
        _material = GetComponent<Renderer>().material;

        StartCoroutine(StartGlitch());
    }

    IEnumerator StartGlitch()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_timeRange.x, _timeRange.y));
            _material.SetFloat(Glitch, 1);
            
            yield return new WaitForSeconds(_timeWait);
            _material.SetFloat(Glitch, 0);

        }
    }
}