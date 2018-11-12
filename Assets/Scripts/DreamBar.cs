using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamBar : MonoBehaviour {

    float fill;
    [SerializeField] float total = 2000;

    private GameController game;

    public Image image;

	// Use this for initialization
	void Start () {
        fill = 0;
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        image.fillAmount = fill / total;
	}

    public void Fill(float amount) {
        StartCoroutine(BeginFilling(amount));
    }

    private IEnumerator BeginFilling(float amount) {
        amount += fill;
        while (fill != amount) {
            fill += amount / 50f;
            yield return new WaitForFixedUpdate();
        }

        game.Full(fill >= total);
    }

    public void setGame(GameController currentGame) {
        game = currentGame;
    }
}
