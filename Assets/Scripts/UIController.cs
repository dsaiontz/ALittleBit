using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;
public class UIController : MonoBehaviour {

    public Text HealthText;
    public Text KurenCText;
    public PlatformerCharacter2D pc2d;
    public Slider HealthSlider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HealthText.text = "Health: " + pc2d.getHealth();
        KurenCText.text = "Kuren C's: " + pc2d.getKurenCs();
        HealthSlider.value = pc2d.getHealth() / pc2d.getMaxHealth();
	}
}
