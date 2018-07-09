using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController _controller;
    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = 9.8f;
    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _hitMarkerPrefab;
    [SerializeField]
    private AudioSource _weaponAudio;
    [SerializeField]
    private int currentAmmo;
    [SerializeField]
    private int maxAmmo = 50;

    private bool _isReloading = false;
    private UIManager _uiManager;

    public bool hasCoin = false;

    [SerializeField]
    private GameObject _weapon;

    // Use this for initialization
	void Start ()
    {
        _controller = GetComponent<CharacterController>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        currentAmmo = maxAmmo;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(_weapon.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R) && !_isReloading)
            {
                _isReloading = true;
                StartCoroutine(Reload());
            }

            if (Input.GetMouseButton(0) && currentAmmo > 0)
            {
                Shoot();
            }
            else
            {
                _muzzleFlash.SetActive(false);
                _weaponAudio.Stop();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }

        CalculateMovement();
	}

    void Shoot()
    {
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;

        currentAmmo--;
        _uiManager.UpdateAmmo(currentAmmo);

        if (!_weaponAudio.isPlaying)
            _weaponAudio.Play();

        _muzzleFlash.SetActive(true);

        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            Debug.Log("Hit: " + hitInfo.transform.name);
            GameObject hitMarker = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal)) as GameObject;
            Destroy(hitMarker, 1.0f);
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;

        velocity = transform.transform.TransformDirection(velocity);

        _controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator Reload()
    {
        _uiManager.ReloadOn();
        yield return new WaitForSeconds(1.5f);
        currentAmmo = maxAmmo;
        _uiManager.UpdateAmmo(currentAmmo);
        _isReloading = false;
        _uiManager.ReloadOff();
    }

    public void EnableWeapons()
    {
        _weapon.SetActive(true);
        _uiManager.WeaponOn();
    }
}
