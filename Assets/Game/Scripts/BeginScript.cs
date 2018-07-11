using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginScript : MonoBehaviour {

    private UIManager _uIManager;

    public void Start()
    {
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            _uIManager.FadeGameTextInOut(1, 2, "Whoa, what's that crate doing here? I wonder if there is a way to destroy it...");
            Destroy(this.gameObject);
        }
    }
}
