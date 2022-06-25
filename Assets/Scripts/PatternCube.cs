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
        Debug.Log("Started Coroutine");

        _showingSequenceColor = true;

        Color newPatternCubeColor = GetRandomColor();

        _meshRenderer.material.color = newPatternCubeColor;

        _activeColorSequence.Add(newPatternCubeColor);
        _positionInColorSequence++;

        yield return new WaitForSeconds(_timeBetweenColorsDelay);
        _showingSequenceColor = false;
        Debug.Log("Ended Couroutine");
    }

    Color GetRandomColor()
    {
        int randomColorIndex = UnityEngine.Random.Range(0, _possibleColors.Length);
        return _possibleColors[randomColorIndex];
    }
}
