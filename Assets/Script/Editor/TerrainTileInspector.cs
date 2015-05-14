using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;

[CustomEditor(typeof(TerrainTile))]
public class TerrainTileInspector : Editor {
    TerrainTile terrainTile;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        terrainTile = (TerrainTile)target;

        int materialTypeNum = Enum.GetValues(typeof(TerrainTile.eTerrainType)).Length;
        for (int i = 0; i < materialTypeNum; ++i) {
            if (i >= terrainTile.materialList.Count) {
                terrainTile.materialList.Add(null);
            }

            EditorGUILayout.LabelField(Enum.GetName(typeof(TerrainTile.eTerrainType), i));
            terrainTile.materialList[i] = (Material)EditorGUILayout.ObjectField(terrainTile.materialList[i], typeof(Material));
        }

        terrainTile.TileTerrainType = (TerrainTile.eTerrainType)EditorGUILayout.EnumPopup("Terrain Type", terrainTile.TileTerrainType);     
    }
}

