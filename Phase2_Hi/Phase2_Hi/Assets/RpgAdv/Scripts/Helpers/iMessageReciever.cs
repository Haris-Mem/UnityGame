using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RpgAdv

{ 
 public enum MessageType
{
    DAMAGED,
    DEAD
}

    public interface IMessageReceiver
    {
        void OnReceiveMessage(MessageType type);
    }
}

