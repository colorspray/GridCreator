using UnityEngine;
using System.Collections;
using System;
using UnityEditor;

[CustomEditor(typeof(TerrainTile))]
public class TerrainTileInspector : Editor {
    TerrainTile terrainTile;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        terrainTile = (TerrainTile)target;
        terrainTile.TileTerrainType = (TerrainTile.eTerrainType)EditorGUILayout.EnumPopup("Terrain Type", terrainTile.TileTerrainType);     
    }

}
