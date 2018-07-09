using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

    [SerializeField]
    private GameObject _crateDestroyed;

    private UIManager _uIManager;

    public void Start()
    {
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    public void DestroyCrate()
    {
        Instantiate(_crateDestroyed, transform.position, transform.rotation);

        Debug.Log(tag);
        if(this.tag == "Devine_Crate")
            _uIManager.FadeGameTextInOut(2, 2, "Good job, you completed the heroic quest of destroying the crate!");
        Destroy(this.gameObject);
    }
}
