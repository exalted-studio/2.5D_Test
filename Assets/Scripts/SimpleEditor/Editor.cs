using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor : MonoBehaviour
{
    public int gridWidth;
    public int gridHeight;
    public int tileSize;

    public GameObject wallPrefab;
    public GameObject floorPrefab;

    public Texture2D[] availableSprites;
    public Texture2D wallSprite;
    public Texture2D wallTopSprite;

    private GameObject[,] tiles;
    private Tile.Data[] tilesTest;

    private float sqrt2 = Mathf.Sqrt(2);

    // Start is called before the first frame update
    void Start()
    {
        tiles = new GameObject[gridWidth, gridHeight];
        tilesTest = new Tile.Data[gridWidth * gridHeight];

        int i = 0;
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                float posX = x * tileSize;
                float posY = y * tileSize * sqrt2;
                float posZ = 0;
                float rotX = 0;
                bool wall = (Random.value > 0.9);

                if (wall)
                {
                    posY -= sqrt2 / 2;
                    posZ -= sqrt2;
                    rotX = -90;
                }

                Quaternion rot = Quaternion.Euler(new Vector3(rotX, 0, 0));
                GameObject newTile;
                if (wall)
                {
                    newTile = Instantiate(wallPrefab, new Vector3(posX, posY, posZ), rot);
                }
                else
                {
                    newTile = Instantiate(floorPrefab, new Vector3(posX, posY, posZ), rot);
                }
                // newTile.transform.localScale = new Vector3(1, (wall ? 2 : 1) * sqrt2, 1);

                Tile tile = newTile.GetComponent<Tile>();
                tile.data = new Tile.Data()
                {
                    id = i,
                    x = x,
                    y = y
                };

                newTile.GetComponent<MeshRenderer>().material.SetTexture("_BaseMap", availableSprites[Random.Range(0, availableSprites.Length)]);
                if (wall)
                {
                    newTile.GetComponent<MeshRenderer>().material.SetTexture("_BaseMap", wallSprite);
                    newTile.transform.GetChild(0).GetComponent<MeshRenderer>().material.SetTexture("_BaseMap", wallTopSprite);

                }
                tiles[x, y] = newTile;
                tilesTest[i] = tile.data;
                Debug.Log(i);
                i++;
            }
        }

        string json = JsonUtility.ToJson(tilesTest);
        Debug.Log(json);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
