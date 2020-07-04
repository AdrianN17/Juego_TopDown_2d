using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class bala:MonoBehaviour
{
    public Timer _timer;
    public List<propiedadesBalas> _balas;
    public int _armaIndex;
    public enum accionesBalas { nada, disparando, recargando};
    public accionesBalas _acciones;
    public LineRenderer _lineRenderer;
    public float _distance;
    public float _angle;
    public GameObject _point;

    public Controlador _controlador;

    void Start() {
        _lineRenderer.enabled = false;
    }

    public void disparo()
    {
        _acciones = accionesBalas.disparando;

        var stock = _balas[_armaIndex]._stock;


        if(_timer == null && stock>0)
        {
            generarBala();

            _timer = Timer.Register(_balas[_armaIndex]._delay,
                delegate()
                {
                    generarBala();
                }
            ,isLooped:true);
        }
            
    }

    public void detenerDisparo()
    {
        _acciones = accionesBalas.nada;

        if(_timer != null)
        {
            _timer.Cancel();
            _timer = null;
        }
    }

    public void recargar()
    {
        _acciones = accionesBalas.recargando;
    }

    public void detenerRecarga()
    {
        _acciones = accionesBalas.nada;
    }

    public Boolean compararAccionesNada()
    {
        return _acciones == accionesBalas.nada;
    }

    public void generarBala()
    {
        
        #region crear bala


            var angleR = Mathf.Deg2Rad * (_angle -180);
            var x = ((float)Math.Cos(angleR) * _distance) ;
            var y =((float)Math.Sin(angleR) * _distance) ;

            var to =  new Vector2(x,y);
            var toArreglado = new Vector2(_point.transform.position.x + x,_point.transform.position.y +y);


            RaycastHit2D hitInfo = Physics2D.Raycast(_point.transform.position, to, Vector2.Distance(_point.transform.position,toArreglado));

            if(hitInfo)
            {
                objetivos(hitInfo.collider.gameObject, hitInfo.point);

                _lineRenderer.enabled = true;
                _lineRenderer.SetPosition(0,_point.transform.position);
                _lineRenderer.SetPosition(1, hitInfo.point);

            }
            else 
            {
                _lineRenderer.enabled = true;
                _lineRenderer.SetPosition(0,_point.transform.position);
                _lineRenderer.SetPosition(1, toArreglado);

            }

            var time = Timer.Register(0.05f, ()=> _lineRenderer.enabled = false);


            Debug.DrawRay(_point.transform.position,to,Color.blue);

        #endregion


        _balas[_armaIndex]._stock --;


        if(_balas[_armaIndex]._stock <= 0)
        {
            if(_timer != null)
            {
                _timer.Cancel();
                _timer = null;
            }
        }


    }


    public void objetivos(GameObject obj,Vector2 punto)
    {
        switch(obj.name)
        {
            case "Destruible":{

                var tilemap = obj.GetComponent<Tilemap>();

                var tilePos = tilemap.WorldToCell(punto);


                if(tilemap.GetTile(tilePos))
                {
                    var name = tilemap.GetTile(tilePos).name;

                    var cadena = name.Replace("tilesheet_complete_", "");

                    _controlador.cambiarTile(tilemap, tilePos, cadena);
                }


                break;
            }
        }
    }

}