using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Button : XRGrabInteractable
{
    [System.Obsolete]
    protected override void OnActivate(XRBaseInteractor interactor)
    {
        MoveController.controller.buttonEvent();
    }
}
