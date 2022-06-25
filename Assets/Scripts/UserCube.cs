using System.Collections.Generic;
using UnityEngine;

public class UserCube : MonoBehaviour
{
    public List<Color> _currentSequencePressed;
    int _positionInSequence;
    Color _currentClickedColor;

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
                _currentClickedColor = GetClickedCubeFaceColor.Instance.GetCubeFaceColor(raycastHit);

                _currentSequencePressed.Add(_currentClickedColor);
            }
        }
    }
    bool ObjectWasUserCube(RaycastHit raycastHit)
    {
        return raycastHit.collider.GetComponent<UserCube>() != null;
    }
}
