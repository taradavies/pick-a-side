using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCube : MonoBehaviour
{
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
                GetClickedCubeFaceColor.Instance.GetCubeFaceColor(raycastHit);
            }
        }
    }

    
    bool ObjectWasUserCube(RaycastHit raycastHit)
    {
        return raycastHit.collider.GetComponent<UserCube>() != null;
    }
}
