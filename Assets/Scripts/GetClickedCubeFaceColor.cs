using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetClickedCubeFaceColor : MonoBehaviour
{
    // [TEST PURPOSES]
    [SerializeField] TestCube _testCube;
    [SerializeField] UserCube _userCube;
    void Update()
    {
        bool isRightMouseButtonClicked = Input.GetMouseButtonDown(0);
        if (isRightMouseButtonClicked)
        {
            CheckIfObjectWasHit();
        }
    }

    void CheckIfObjectWasHit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var raycastHit, 100f))
        {
            if (ObjectWasUserCube(raycastHit))
            {
                GetCubeFaceColor(raycastHit);
            }
        }
    }

    void GetCubeFaceColor(RaycastHit hit)
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

    bool ObjectWasUserCube(RaycastHit raycastHit)
    {
        return raycastHit.collider.GetComponent<UserCube>() != null;
    }
}
