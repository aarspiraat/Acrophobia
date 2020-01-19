﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : Interactable
{
    private Socket socket = null;

    private void Awake()
    {
        socket = GetComponent<Socket>();
    }

    public override void StartInteraction(Hand hand)
    {
        if (hand.HasHeldObject())
        {
            TryStore(hand);
        }
        else
        {
            TryRetrieve(hand);
        }
    }

    private void TryStore(Hand hand)
    {
        if (socket.GetStoredObject())
            return;

        Moveable objectToStore = hand.Drop();
        objectToStore.AttachNewSocket(socket);
    }

    private void TryRetrieve(Hand hand)
    {

        if (!socket.GetStoredObject())
            return;

        Moveable objectToRetrieve = socket.GetStoredObject();
        hand.Pickup(objectToRetrieve);
    }
}
