using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondHand : MonoBehaviour {

    private UIManager _uIManager;

    public void Start()
    {
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    
                    _uIManager.FadeGameTextInOut(1, 2, "Twenty schmeckles?! You ain't getting any fleeb for that!");
                }
            }
        }
    }
}
