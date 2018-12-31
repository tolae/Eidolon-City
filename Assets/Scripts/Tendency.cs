using UnityEngine;
using UnityEngine.Events;

public abstract class Tendency : MonoBehaviour {
    /* System event that passes handling to the active tendency. Pass 3 parameters:
     *      Tendency_Type: The type of the tendency that is active.
     *      Bool: Whether or not this tendency is triggered (if applicable).
     *      ITendencParameter: The parameter for the specific tendency.
     */
    [System.Serializable]
    public class TendencyEvent : UnityEvent<Tendency_Type, bool, ITendencyParameter> { };
    /* Holds specific information that each tendency implements. */
    public interface ITendencyParameter { }
    public TendencyEvent tendencyEvent;
    /* The different types of tendencies */
    public enum Tendency_Type {
        HIVEMIND, /* Information is shared between those in the same hivemind */
        SPAWNER, /* Creates other mobs (or itself) */
        MOB_MENTALITY, /* Makes mobs want to group up */
        HORROR, /* AoE persistant slow effect */
    }
    /* Determines whether the tendency is currently active or not. */
    public abstract bool IsActive();
}