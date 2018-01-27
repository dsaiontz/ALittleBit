using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class CollectibleManager : MonoBehaviour {

    public float smallHealAmount;
    private PlatformerCharacter2D platChar;

    void Start()
    {
        platChar = GetComponent<PlatformerCharacter2D>();
    }
	void OnTriggerEnter2D(Collider2D col)
    {
        string tag = col.gameObject.tag;
        if (tag == "SmallHeal")
        {
            platChar.healDamage(smallHealAmount);
            col.gameObject.SetActive(false);
        }
    }
}
