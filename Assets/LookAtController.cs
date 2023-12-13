using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtController : MonoBehaviour
{
    private ObejctWithDescription previousObject;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 6f))
        {
            var objWithDesc = hit.transform.gameObject.GetComponent<ObejctWithDescription>();
            if (objWithDesc != null)
            {
                previousObject = objWithDesc;
                objWithDesc.ShowDescriptionSet();
            }
            else
            {
                if(previousObject != null)
                {
                    previousObject.StopDescriptionSet();
                }
            }
        }
        else
        {
            if (previousObject != null)
            {
                previousObject.StopDescriptionSet();
            }
        }
    }
}
