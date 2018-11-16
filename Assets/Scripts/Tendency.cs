using UnityEngine;
using UnityEngine.Events;

public abstract class Tendency : MonoBehaviour {
    
    [System.Serializable]
    public class TendencyEvent : UnityEvent<Tendency_Type> { };
    public TendencyEvent tendencyEvent;

    public enum Tendency_Type {
        HIVEMIND_ON, HIVEMIND_OFF
    }

    public Tendency_Type[] type_pair = new Tendency_Type[2];
}