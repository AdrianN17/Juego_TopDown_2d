using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerColisiones : MonoBehaviour
{
    public player _player;
    public bala _balas;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) {
        
        switch(other.gameObject.tag)
        {
            case "Item": {

                var script = other.gameObject.GetComponent<ItemData>();
                ItemAccion(script);

                break;
            }
        }
    }

    public void ItemAccion(ItemData itemData)
    {
        switch(itemData.accion)
        {
            case "recargar":{

                AccionesLibs.recargar(itemData.gameObject,_balas._balas[itemData.tipo],itemData);

                break;
            }
            case "curar":{

                AccionesLibs.curar(itemData.gameObject,_player._vida,itemData);

                break;
            }
        }
    }
}
