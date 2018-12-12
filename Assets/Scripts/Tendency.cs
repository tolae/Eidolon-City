using UnityEngine;
using UnityEngine.Events;

public abstract class Tendency : MonoBehaviour {
    
    [System.Serializable]
    public class TendencyEvent : UnityEvent<Tendency_Type, bool, ITendencyParameter> { };
    public interface ITendencyParameter { }
    public TendencyEvent tendencyEvent;

    public enum Tendency_Type {
        HIVEMIND,
        SPAWNER,
        MOB_MENTALITY,
    }

    public abstract bool IsActive();
}