using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Controlador : MonoBehaviour
{
    public List<tilemapCambio> listadoTiles;
    public Tilemap tilemapNuevo;
    public List<GameObject> itemList;
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

    public void crearItem(Vector3 pos)
    {

        var x1 = Random.Range(0,2);
 
        if(x1 == 1)
        {

            var x2 = Random.Range(0,itemList.Count);

            Instantiate(itemList[x2],pos, Quaternion.identity);
        }

    }

    public void objetivos(RaycastHit2D hit)
    {

        var obj = hit.collider.gameObject;

        switch(obj.tag)
        {
            case "Destruible":{  

                var tilemap = obj.GetComponent<Tilemap>();

                
                var tilePos = tilemap.WorldToCell(hit.point - (hit.normal * 0.25f));
                    

                if(tilemap.GetTile(tilePos))
                {
                    var name = tilemap.GetTile(tilePos).name;

                    var cadena = name.Replace("tilesheet_complete_", "");

                    cambiarTile(tilemap, tilePos, cadena);
                    
                    var worldPos = tilemap.GetCellCenterWorld(tilePos);

                }

                break;
            }
            case "DestruibleConItems":{

                var tilemap = obj.GetComponent<Tilemap>();

                
                var tilePos = tilemap.WorldToCell(hit.point - (hit.normal * 0.25f));
                    

                if(tilemap.GetTile(tilePos))
                {
                    var name = tilemap.GetTile(tilePos).name;

                    var cadena = name.Replace("tilesheet_complete_", "");

                    cambiarTile(tilemap, tilePos, cadena);
                    
                    var worldPos = tilemap.GetCellCenterWorld(tilePos);

                    crearItem(worldPos);
                }

                break;
            }
        }
    }
}
