using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Controlador : MonoBehaviour
{
    public List<tilemapCambio> listadoTiles;
    public Tilemap tilemapNuevo;
    // Start is called before the first frame update
    public void cambiarTile(Tilemap tilemap, Vector3Int pos, string tipo)
    {

        Tile tile = null;

        foreach(var tilesCambio in listadoTiles)
        {
            foreach(var nombre in tilesCambio.listado)
            {
                if(nombre == tipo)
                {
                    var numero = Random.Range(0,tilesCambio.tiles.Count);

                    tile = tilesCambio.tiles[numero];
                    break;
                }
            }
        }

        if(tile)
        {
            tilemap.SetTile(pos,null);
            tilemapNuevo.SetTile(pos,tile);
        }

            
    }
}
