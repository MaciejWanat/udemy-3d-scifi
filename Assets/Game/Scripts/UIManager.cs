using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private Text _ammoText;
    [SerializeField]
    private Text _reloadText;
    [SerializeField]
    private Image _crossHair;
    [SerializeField]
    private GameObject _coin;

    public void CollectedCoin()
    {
        _coin.SetActive(true);
    }

    public void UpdateAmmo(int count)
    {
        _ammoText.text = "Ammo: " + count;
    }

    public void ReloadOn()
    {
        _reloadText.enabled = true;
        _crossHair.enabled = false;
    }

    public void ReloadOff()
    {
        _reloadText.enabled = false;
        _crossHair.enabled = true;
    }

    public void RemoveCoin()
    {
        _coin.SetActive(false);
    }

    public void WeaponOn()
    {
        _ammoText.enabled = true;
    }
}

