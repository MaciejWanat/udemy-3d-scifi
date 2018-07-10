using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField]
    private AudioClip _coinPickUp;
    private UIManager _uIManager;

    private void Start()
    {
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    
    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            _uIManager.IndicateActionOn("Pick up");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    player.hasCoin = true;
                    AudioSource.PlayClipAtPoint(_coinPickUp, transform.position, 1f);

                    UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

                    if(uiManager)
                    {
                        uiManager.CollectedCoin();
                    }

                    _uIManager.IndicateActionOff();
                    Destroy(this.gameObject);
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        _uIManager.IndicateActionOff();
    }

}
