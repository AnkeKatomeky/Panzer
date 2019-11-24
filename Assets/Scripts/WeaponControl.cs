using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public GameObject Canon;
    public GameObject Mortar;
    public GameObject MortarTarget;

    public GameObject CanonCharge;
    public GameObject MortarCharge;

    public float SwitchTimeout;
    public float FireTimeout;

    private bool _isCanon;
    private bool _isChanging;
    private bool _isFiring;

    private float _timeToChange;
    // Start is called before the first frame update
    void Start()
    {
        _isCanon = true;
        _isChanging = false;
        _isFiring = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isChanging)
        {
            _timeToChange -= Time.deltaTime;

            if (_timeToChange < 0)
            {
                _isChanging = false;
            }
        }

        if (_isFiring)
        {
            _timeToChange -= Time.deltaTime;

            if (_timeToChange < 0)
            {
                _isFiring = false;
            }
        }
    }

    public void ChangeWeapon()
    {
        if (!_isChanging)
        {
            _timeToChange = SwitchTimeout;
            _isCanon = !_isCanon;
            _isChanging = true;
            if (_isCanon)
            {
                Canon.SetActive(true);
                Mortar.SetActive(false);
                MortarTarget.SetActive(false);
            }
            else
            {
                Canon.SetActive(false);
                Mortar.SetActive(true);
                MortarTarget.SetActive(true);
            }
        }
    }

    public void Fire()
    {
        if (!_isFiring)
        {
            _timeToChange = FireTimeout;
            GameObject charge;
            _isFiring = true;
            if (_isCanon)
            {
                charge = Instantiate(CanonCharge);
                charge.transform.position = Canon.transform.position;
                charge.transform.rotation = Canon.transform.rotation;
            }
            else
            {
                charge = Instantiate(MortarCharge);
                charge.transform.position = Mortar.transform.position;
                charge.transform.rotation = Mortar.transform.rotation;
            }
        }
    }
}
