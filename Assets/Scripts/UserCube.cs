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
                // else
                // {
                //     // transition to game over screen
                // }
            }
        }
    }
    bool SequenceIsCompleted()
    {
        List<Color> patternCubeSequence = PatternCube.Instance.GetActiveColorSequence();
        return _currentSequencePressed.Count >= patternCubeSequence.Count
        && BothSequencesAreEqual(patternCubeSequence);
    }

    bool BothSequencesAreEqual(List<Color> patternCubeSequence)
    {        
        for (int x = 0; x < patternCubeSequence.Count; x++)
        {
            if (ColorsAreNotEqual(patternCubeSequence, x))
            {
                Debug.Log("They are not equal...");
                return false;
            }
        }
        Debug.Log("They are equal!");
        return true;
    }

    bool ColorsAreNotEqual(List<Color> patternCubeSequence, int x)
    {
        Color patternColor = patternCubeSequence[x];
        Color sequenceColor = _currentSequencePressed[x];

        float redInBothColors = Math.Abs(patternColor.r - sequenceColor.r);
        float greenInBothColors = Math.Abs(patternColor.g - sequenceColor.g);
        float blueInBothColors = Math.Abs(patternColor.b - sequenceColor.b);

        return !(redInBothColors <= 0.1 && greenInBothColors <= 0.1 && blueInBothColors <= 0.1);
    }

    bool ObjectWasUserCube(RaycastHit raycastHit)
    {
        return raycastHit.collider.GetComponent<UserCube>() != null;
    }
}
