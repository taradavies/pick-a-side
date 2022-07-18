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

    public Color GetCubeFaceColor(RaycastHit hit)
    {
        MeshRenderer meshRenderer = hit.transform.GetComponent<MeshRenderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;

        Texture2D tex = meshRenderer.material.mainTexture as Texture2D;

        Vector2 pixelUV = hit.textureCoord;

        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;

        // [TESTING PURPOSES]

        Color faceColor = tex.GetPixel((int) pixelUV.x, (int) pixelUV.y);

        Color newFaceColor = new Color(faceColor.r, faceColor.g, faceColor.b, 0);
        

        _testCube.SetCurrentColor(newFaceColor);

        return newFaceColor;
    }
}
