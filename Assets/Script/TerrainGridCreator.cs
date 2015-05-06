using UnityEngine;
using System.Collections;

public class TerrainGridCreator : MonoBehaviour {
    public enum TerrainGridType {
        HEX,
        SQUIRE,
    };

    public TerrainGridType terrainGridType;
    public int rows = 0;
    public int column = 0;
    public float tileDistance = 10f;
    public TerrainTile terrainTile = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
