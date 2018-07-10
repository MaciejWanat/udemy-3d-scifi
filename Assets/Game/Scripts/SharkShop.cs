using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour {

    private UIManager _uIManager;
    private AudioSource _win;
    private AudioSource _shark;

    public void Start()
    {
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        AudioSource[] audios = GetComponents<AudioSource>();
        _win = audios[0];
        _shark = audios[1];
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            _uIManager.IndicateActionOn("Talk [E]");
            if (Input.GetKeyDown(KeyCode.E))
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

                        _win.Stop();
                        _win.Play();

                        _shark.Stop();
                        _shark.Play();

                        player.EnableWeapons();
                        _uIManager.FadeGameTextInOut(1, 2, "Tasty coin! Here, have your weapon!");
                    }
                    else
                    {
                        _shark.Stop();
                        _shark.Play();

                        if (player.IsWeaponActive())
                            _uIManager.FadeGameTextInOut(1, 2, "Yarr, you have fun with your weapon, me have fun with my coin!");
                        else
                            _uIManager.FadeGameTextInOut(1, 2, "Yarr, no coin, no weapon. If only there would be any shiny coin nearby...");
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        _uIManager.IndicateActionOff();
    }
}
