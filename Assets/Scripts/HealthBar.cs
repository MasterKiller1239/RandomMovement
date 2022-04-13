using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private Slider bar;

	private void Awake () {
   
	}

    public void SetFill(float sizeNormalized) {
        bar.value = sizeNormalized;
    }

    
}
