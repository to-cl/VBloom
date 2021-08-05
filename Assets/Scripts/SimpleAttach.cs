using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SimpleAttach : MonoBehaviour
{
    private Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void onHandHoverBegin(Hand hand) {
        hand.ShowGrabHint();
    }

    private void onHandHoverEnd(Hand hand) {
        hand.HideGrabHint();
    }

    private void HandHoverUpdate(Hand hand) {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        //grab object
        if(interactable.attachedToHand == null && grabType != GrabTypes.None) {
            hand.AttachObject(gameObject, grabType);
            hand.HoverLock(interactable);
            hand.HideGrabHint();
        }
        //release object
        else if(isGrabEnding) {
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
