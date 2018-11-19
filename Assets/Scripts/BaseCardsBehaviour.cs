using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCardsBehaviour : MonoBehaviour {

    public GameObject front;
    public Vector3 rotation;
    public RectTransform trans;

	void Start () {
		
	}

	void Update () {
        CardsBack();
        rotation = new Vector3(trans.rotation.x, transform.rotation.y, Mathf.Abs(transform.rotation.z));
	}
    void CardsBack ()
    {
        if(Mathf.Abs(transform.rotation.x) >= 90|| Mathf.Abs(transform.rotation.y) >= 90 ) front.SetActive(false);
        else front.SetActive(true);
    }
}
