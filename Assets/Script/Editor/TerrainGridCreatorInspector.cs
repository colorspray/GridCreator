using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(TerrainGridCreator))]
public class TerrainGridCreatorInspector : Editor {
    TerrainGridCreator terrainGridCreator;
    float HEX_DISTANCE_X = Mathf.Sqrt(3.0f) / 2.0f; // to calculate tile positions in hex grid

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        terrainGridCreator = (TerrainGridCreator)target;
        if (GUILayout.Button("Clear and create Grid")) {
            ClearGrid();
            CreateGrid();
        }

        if (GUILayout.Button("Update Tile")) {
            UpdateTileInfo();
        }
    }

    private void ClearGrid(){
        for (int i = terrainGridCreator.transform.childCount - 1; i >= 0; --i ) {
            DestroyImmediate(terrainGridCreator.transform.GetChild(i).gameObject);
        }
    }

    private void CreateGrid(){
        if (terrainGridCreator.terrainTile == null || terrainGridCreator.terrainTile.gameObject == null)
            return;

        if (terrainGridCreator.terrainGridType == TerrainGridCreator.TerrainGridType.SQUIRE) {
            GreateGridSquire();
        }
        else if (terrainGridCreator.terrainGridType == TerrainGridCreator.TerrainGridType.HEX) {
            GreateGridHex();
        }
    }

    private void GreateGridSquire() {
        for (int i = 0; i < terrainGridCreator.rows; ++i) {
            for (int j = 0; j < terrainGridCreator.column; ++j) {
                CreateTile(i, j, i * terrainGridCreator.tileDistance, j * terrainGridCreator.tileDistance);
            }
        }
    }

    private void GreateGridHex() {   
        float tempPosX, tempPosZ; 

        for (int i = 0; i < terrainGridCreator.rows; ++i) {
            if (i % 2 == 0) {
                for (int j = 0; j < terrainGridCreator.column; ++j) {
                    tempPosX = i * HEX_DISTANCE_X * terrainGridCreator.tileDistance;
                    tempPosZ = j * terrainGridCreator.tileDistance;
                    CreateTile(i, j, tempPosX, tempPosZ);
                }
            }
            else {
                for (int j = 0; j < terrainGridCreator.column + 1; ++j) {

                    tempPosX = i * HEX_DISTANCE_X * terrainGridCreator.tileDistance;
                    tempPosZ = (j - 0.5f) * terrainGridCreator.tileDistance;
                    CreateTile(i, j, tempPosX, tempPosZ);
                }
            }
        }
    }

    private void CreateTile(int i, int j, float x, float z) {
        GameObject tempTile = GameObject.Instantiate(terrainGridCreator.terrainTile.gameObject);
        tempTile.transform.SetParent(terrainGridCreator.transform);
        tempTile.transform.localScale *= terrainGridCreator.tileDistance;
        tempTile.transform.localPosition = new Vector3(x, 0, z);
        tempTile.name = "Tile:" + i + ":" + j;
    }

    private void UpdateTileInfo() {
        foreach (TerrainTile tile in terrainGridCreator.GetComponentsInChildren<TerrainTile>()) {
            tile.materialList = terrainGridCreator.terrainTile.materialList;
        }
    }
}
