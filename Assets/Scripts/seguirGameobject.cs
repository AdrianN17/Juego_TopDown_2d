using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguirGameobject : MonoBehaviour
{
    public GameObject _obj;
    private Vector3 _pos;
    public bool _visible;
    void Start()
    {
        _pos = this.transform.position -  _obj.transform.position;
    }

    void Update() {
        if(_visible)
            this.transform.position = _obj.transform.position + _pos;
    }
   
}
