using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamBar : MonoBehaviour {
    /* How full the bar is (not a percentage) */
    float fill;
    /* The amount required to fill the bar */
    [SerializeField] float total = 2000;
    /* The visual of the bar */
    public Image image;

	// Use this for initialization
	void Start () {
        fill = 0;
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        /* Calculates the percentage of the bar that should be full */
        image.fillAmount = fill / total;
	}
    /* Slowly fills the bar by the amount given */
    public void Fill(float amount) {
        StartCoroutine(BeginFilling(amount));
    }
    /* Method that fills the bar slowly versus instantly. */
    private IEnumerator BeginFilling(float amount) {
        amount += fill;
        while (fill != amount) {
            fill += amount / 50f;
            yield return new WaitForFixedUpdate();
        }

        GameController.instance.Full(fill >= total);
    }
}
