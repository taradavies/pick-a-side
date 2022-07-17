using System;
using System.Collections.Generic;
using UnityEngine;

public class UserCube : MonoBehaviour
{
    List<Color> _currentSequencePressed = new List<Color>();
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

                Debug.Log("Sequence pressed length: " + _currentSequencePressed.Count);

                if (SequenceIsCompleted())
                {
                    _currentSequencePressed.Clear();
                    PatternCube.Instance.GenerateNewSequence();
                }
            }
        }
    }
    bool SequenceIsCompleted()
    {
        List<Color> patternCubeSequence = PatternCube.Instance.GetActiveColorSequence();
        return _currentSequencePressed.Count >= patternCubeSequence.Count;
    }

    bool ObjectWasUserCube(RaycastHit raycastHit)
    {
        return raycastHit.collider.GetComponent<UserCube>() != null;
    }
}
