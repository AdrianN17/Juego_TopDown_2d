using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public Collider2D _colPlayer;

    public Vector2 _minPos;
    public Vector2 _maxPos;

    public GameObject _min;
    public GameObject _max;


    // Start is called before the first frame update
    void Start()
    {
        _minPos = _min.transform.position;
        _maxPos = _max.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var centro = _colPlayer.bounds.center;
        var vertExtent = Camera.main.orthographicSize;
        var horzExtent = vertExtent * Screen.width / Screen.height;


        var x = Mathf.Clamp(centro.x,_minPos.x + horzExtent ,_maxPos.x - horzExtent);
        var y = Mathf.Clamp(centro.y,_minPos.y + vertExtent  ,_maxPos.y -vertExtent);


        transform.position = new Vector3(x,y,transform.position.z);
    }
}
