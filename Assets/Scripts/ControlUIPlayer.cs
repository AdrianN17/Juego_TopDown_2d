using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlUIPlayer : MonoBehaviour
{
    public player _player;
    public Text _textoStock;
    public Text _textMunicion;
    public Image _imgBarra;
    public Image _imgArma;

    public List<Sprite> _armasImagen;

    void Start()
    {
        Timer.Register(0.05f,delegate(){

            if(_player)
            {
                var arma = _player._balas._balas[_player._balas._armaIndex];

                _textoStock.text = "Municion : " + arma._stock + " / " + arma._maxStock;
                _textMunicion.text = "Municion : " + arma._municion + " / " + arma._maxMunicion;

                var hp = _player._vida;
                var x = MathLib.Remap(hp._vida, 0, hp._maxVida, 0, 1);

                _imgBarra.transform.localScale = new Vector3(x, _imgBarra.transform.localScale.y, _imgBarra.transform.localScale.z);

                _imgArma.sprite = _armasImagen[_player._balas._armaIndex];

            }

        },isLooped:true);
    }

    
}
