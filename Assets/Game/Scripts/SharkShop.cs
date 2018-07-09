using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour {

    private UIManager _uIManager;

    public void Start()
    {
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    if (player.hasCoin == true)
                    {
                        player.hasCoin = false;

                        if (_uIManager != null)
                        {
                            _uIManager.RemoveCoin();
                        }

                        AudioSource audio = GetComponent<AudioSource>();
                        audio.Play();
                        player.EnableWeapons();
                        _uIManager.FadeGameTextInOut(1, 2, "Tasty coin! Here, have your weapon!");
                    }
                    else
                    {
                        if(player.IsWeaponActive())
                            _uIManager.FadeGameTextInOut(1, 2, "Yarr, you have fun with your weapon, me have fun with my coin!");
                        else
                            _uIManager.FadeGameTextInOut(1, 2, "Yarr, no coin, no weapon. If only there would be any shiny coin nearby...");
                    }
                }
            }
        }
    }
}
