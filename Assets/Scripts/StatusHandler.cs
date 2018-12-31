using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatusHandler : MonoBehaviour {

    /* A persistent entity for each world */
    public static StatusHandler instance = null;
    /* The different status' that can be inflicted on a unit */
    public enum Status {
        SLOW,
        STUN,
    }
    /* Parameter all status' must have. Holds different information for each status.
     * ex: Slow = % slow down, slow time, etc
     */
    public interface IStatusParameter { };
    /* The method that handles whether this status will take effect or remove it */
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
