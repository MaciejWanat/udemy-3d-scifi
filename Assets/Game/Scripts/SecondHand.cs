using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondHand : MonoBehaviour {

    private UIManager _uIManager;
    private AudioSource _wubba;

    public void Start()
    {
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _wubba = GetComponent<AudioSource>();
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
                    _wubba.Stop();
                    _wubba.Play();
                    _uIManager.FadeGameTextInOut(1, 2, "Twenty schmeckles?! You ain't getting any fleeb for that!");
                }
            }
        }
    }
}
