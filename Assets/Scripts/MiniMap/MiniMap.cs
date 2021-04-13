using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    private Transform _player;
    private Vector3 _offset= new Vector3(0f,5f,0f);

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.parent = null;
        transform.rotation=Quaternion.Euler(90f,0f,0f);
        transform.position = _player.position + _offset;

        var minimapTexture = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");

        GetComponent<Camera>().targetTexture = minimapTexture;
    }

    private void LateUpdate()
    {
        var curentPlayerPosition = _player.position;
        curentPlayerPosition.y = transform.position.y;
        transform.position = curentPlayerPosition;
    }
}
