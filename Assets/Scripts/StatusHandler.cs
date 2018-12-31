﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatusHandler : MonoBehaviour {

    public static StatusHandler instance = null;

    public enum Status {
        SLOW,
        STUN,
    }

    public interface IStatusParameter { };

    public void HandlePlayerStatus(bool trigger, Status status, IStatusParameter param) {
        Debug.Log(status.ToString() + " : " + trigger);
        switch (status) {
            case Status.SLOW:
                if (trigger)
                    SlowStatus.ApplySlow((SlowStatus.SlowParameter)param);
                else
                    SlowStatus.RemoveSlow();
                break;
            case Status.STUN:
                break;
            default:
                break;
        }
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
}
