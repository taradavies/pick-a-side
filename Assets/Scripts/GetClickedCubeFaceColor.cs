using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetClickedCubeFaceColor : MonoBehaviour
{
    // [TEST PURPOSES]
    [SerializeField] TestCube _testCube;
    [SerializeField] UserCube _userCube;

    public static GetClickedCubeFaceColor Instance;

    void Start()
    {
        Instance = this;
    }

    public void GetCubeFaceColor(RaycastHit hit)
    {
        MeshRenderer meshRenderer = hit.transform.GetComponent<MeshRenderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;

        if (meshRenderer == null || meshRenderer.sharedMaterial == null || meshRenderer.sharedMaterial.mainTexture == null || meshCollider == null)
            return;

        Texture2D tex = meshRenderer.material.mainTexture as Texture2D;
        Vector2 pixelUV = hit.textureCoord;

        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;

        // [TESTING PURPOSES]

        _testCube.SetCurrentColor(tex.GetPixel((int) pixelUV.x, (int) pixelUV.y));
    }
}
