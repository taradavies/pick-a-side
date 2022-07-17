using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternCube : MonoBehaviour
{

    [SerializeField] Color[] _possibleColors;
    [SerializeField] float _timeBetweenColorsDelay = 0.5f;

    public static PatternCube Instance;

    List<Color> _activeColorSequence = new List<Color>();
    MeshRenderer _meshRenderer;

    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        Instance = this;
        _activeColorSequence.Clear();
        AddRandomColorToSequence();
    }

    void AddRandomColorToSequence()
    {
        Color newPatternCubeColor = GetRandomColor();
        
        _activeColorSequence.Add(newPatternCubeColor);
        ChangeCubeColor(newPatternCubeColor);
    }

    public void GenerateNewSequence()
    {
        AddRandomColorToSequence();
        StartCoroutine(PlaybackOldSequence());
    }

    IEnumerator PlaybackOldSequence()
    {
        foreach (Color color in _activeColorSequence)
        {
            ChangeCubeColor(color);
            yield return new WaitForSeconds(_timeBetweenColorsDelay);
        }
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
    public List<Color> GetActiveColorSequence()
    {
        return _activeColorSequence;
    }
}
