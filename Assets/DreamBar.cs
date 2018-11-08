using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamBar : MonoBehaviour {

    float percentageFull;
    float fill;
    [SerializeField] float total = 2000;

    public Image image;

	// Use this for initialization
	void Start () {
        percentageFull = 0f;
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        percentageFull = fill / total;
        image.fillAmount = percentageFull;
	}

    public void Fill(float amount) {
        StartCoroutine(BeginFilling(amount));
    }

    private IEnumerator BeginFilling(float amount) {
        while (fill != amount) {
            fill += amount / 50f;
            yield return new WaitForFixedUpdate();
        }
    }
}
