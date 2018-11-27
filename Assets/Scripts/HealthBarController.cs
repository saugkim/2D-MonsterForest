using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {

    private Slider slider;
    public int healthValue;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = healthValue;
	}
}
