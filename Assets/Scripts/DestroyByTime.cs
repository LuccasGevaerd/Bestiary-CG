using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

    public int timer = 5;
    float cloack;

	void Update () {
        cloack += Time.deltaTime;
        if (cloack >= timer) Destroy(gameObject);
	}
}
