
using UnityEngine;

public static class AccionesLibs{

    public static void recargar(GameObject obj, propiedadesBalas bala, ItemData itemData)
    {
        if(bala._municion<bala._maxMunicion)
        {
            var cantidad = bala._municion + itemData.valor; 

            bala._municion = Mathf.Min(bala._maxMunicion, cantidad);

            var cantidad2 = cantidad - bala._maxMunicion;

            if(cantidad2>0)
            {
               itemData.valor =cantidad2;
            }
            else
            { 
                GameObject.Destroy(obj);
                
            }
        }

    }

    public static void curar(GameObject obj, propiedadesVida vida, ItemData itemData)
    {
        
        if(vida._vida<vida._maxVida)
        {
            vida._vida = Mathf.Min(vida._maxVida,vida._vida + itemData.valor);
            GameObject.Destroy(obj);
        }

    }
}