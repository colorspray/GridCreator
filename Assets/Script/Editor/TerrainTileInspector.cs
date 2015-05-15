using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEditor.AnimatedValues;

[CustomEditor(typeof(TerrainTile))]
public class TerrainTileInspector : Editor {
    TerrainTile terrainTile;
    AnimBool showMaterial;

    void OnEnable() {
        showMaterial = new AnimBool(true);
        showMaterial.valueChanged.AddListener(Repaint);
        terrainTile = (TerrainTile)target;
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        int materialTypeNum = Enum.GetValues(typeof(TerrainTile.eTerrainType)).Length;

        showMaterial.target = EditorGUILayout.ToggleLeft("Show Material List", showMaterial.target);
        if (EditorGUILayout.BeginFadeGroup(showMaterial.faded)) {
            EditorGUI.indentLevel++;
            for (int i = 0; i < materialTypeNum; ++i) {
                if (i >= terrainTile.materialList.Count) {
                    terrainTile.materialList.Add(null);
                }
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel(Enum.GetName(typeof(TerrainTile.eTerrainType), i));
                terrainTile.materialList[i] = (Material)EditorGUILayout.ObjectField(terrainTile.materialList[i], typeof(Material));
                EditorGUILayout.EndHorizontal();
            }
            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndFadeGroup();

        terrainTile.TileTerrainType = (TerrainTile.eTerrainType)EditorGUILayout.EnumPopup("Terrain Type", terrainTile.TileTerrainType);
    }
}

