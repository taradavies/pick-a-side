using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternCube : MonoBehaviour
{

    [SerializeField] Color[] _possibleColors;
    [SerializeField] float _timeBetweenColorsDelay;

    public List<Color> _activeColorSequence = new List<Color>();
    MeshRenderer _meshRenderer;
    int _positionInColorSequence;
    bool _showingSequenceColor = false;

    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (_showingSequenceColor) {return;}

        StartCoroutine(AddRandomColorToSequence());

    }

    void Start()
    {
        _activeColorSequence.Clear();
    }

    IEnumerator AddRandomColorToSequence()
    {
        _showingSequenceColor = true;

        Color newPatternCubeColor = GetRandomColor();
        
        ChangeCubeColor(newPatternCubeColor);
        AddColorToSequence(newPatternCubeColor);

        yield return new WaitForSeconds(_timeBetweenColorsDelay);

        _showingSequenceColor = false;
    }
    Color GetRandomColor()
    {
        int randomColorIndex = UnityEngine.Random.Range(0, _possibleColors.Length);
        return _possibleColors[randomColorIndex];
    }

    void ChangeCubeColor(Color newColor)
    {
        _meshRenderer.material.color = newColor;
    }

    void AddColorToSequence(Color colorToAdd)
    {
        _activeColorSequence.Add(colorToAdd);
        _positionInColorSequence++;
    }
}
