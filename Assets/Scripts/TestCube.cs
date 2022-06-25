using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : MonoBehaviour
{
    MeshRenderer _meshRenderer;
    Color _currentColor;

    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _currentColor = _meshRenderer.material.color;
    }
    void Update()
    {
        _meshRenderer.material.SetColor("_Color", _currentColor);
    }

    public void SetCurrentColor(Color colorClickedByUser)
    {
        _currentColor = colorClickedByUser;
    }
}
