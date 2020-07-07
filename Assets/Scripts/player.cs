using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float _speed;
    public propiedadesVida _vida;

    public SpriteRenderer _sprite;
    public CircleCollider2D _col;
    public Rigidbody2D _rb;

    public List<Sprite> _sprites;

    private Vector2 _center;

    public bala _balas;

    public GameObject _points;

    // Start is called before the first frame update
    void Start()
    {
        _sprite.sprite = _sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        var dt =  Math.Max(Time.deltaTime,1/60f);

        _center = _col.bounds.center;
        var mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var angle = MathLib.AngleBetweenPoints(_center, mousepos);


        _balas._angle = angle;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, (float)angle -180));



        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _balas.detenerDisparo();
            _balas.detenerRecarga();

            _balas._armaIndex = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            _balas.detenerDisparo();
            _balas.detenerRecarga();

            _balas._armaIndex = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            _balas.detenerDisparo();

            _balas._armaIndex = 2;
        }

        

        if(Input.GetMouseButtonDown(0))
        {
            if(_balas.verificarDisparo())
            {
                _balas.disparo();

                _sprite.sprite = _sprites[2 + _balas._armaIndex];
            }

        }
        else if(Input.GetMouseButtonDown(1))
        {
            if(_balas.verificarRecarga())
            {
                _balas.recargar();

                _sprite.sprite = _sprites[5];
            }   
        }

        if(Input.GetMouseButtonUp(0))
        {
            _balas.detenerDisparo();  
        }
        else if(Input.GetMouseButtonUp(1))
        {
           _balas.detenerRecarga();
        }


        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(move != Vector2.zero)
        {
            _rb.velocity = (move * dt * _speed);
        }


        if(_balas.compararAccionesNada())
        {
            if(move != Vector2.zero)
            {
                _sprite.sprite = _sprites[1];
            }
            else 
            {
                _sprite.sprite = _sprites[0];
            }
        } 

       



    }
    
}
