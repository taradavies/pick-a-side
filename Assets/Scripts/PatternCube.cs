using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternCube : MonoBehaviour
{
    [SerializeField] Color[] _possibleColors;

    MeshRenderer _meshRenderer;

    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        int randomColorIndex = UnityEngine.Random.Range(0, 6);
        _meshRenderer.material.color = _possibleColors[randomColorIndex];
    }
}
