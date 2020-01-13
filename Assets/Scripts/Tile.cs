using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public float testValue = 5.0f;
    public Data data;
    // Start is called before the first frame update
    void Start()
    {
        // data = new TileData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    [Serializable]
    public class Data
    {
        public int id;
        public int x;
        public int y;
        public string sprite;
    }
}
