using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitVendor : MonoBehaviour {

    private UIManager _uIManager;
    private AudioSource _rocknroll;

    public void Start()
    {
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _rocknroll = GetComponent<AudioSource>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            _uIManager.IndicateActionOn("Talk");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    _rocknroll.Stop();
                    _rocknroll.Play();
                    _uIManager.FadeGameTextInOut(1, 2, "Fruits, parrots and rock'n'roll!");
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        _uIManager.IndicateActionOff();
    }
}
