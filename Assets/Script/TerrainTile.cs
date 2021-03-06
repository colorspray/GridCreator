﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[ExecuteInEditMode]  
public class TerrainTile : MonoBehaviour {
    public enum eTerrainType {
        GRASS = 0,
        ICE,
        DESERT,
        ROCK
    }

    [HideInInspector]
    public List<Material> materialList = new List<Material>();

    [SerializeField]
    [HideInInspector]
    private eTerrainType tileTerrainType = eTerrainType.GRASS;

    public eTerrainType TileTerrainType {
        set {
            if (materialList[(int)value] != null) {
                gameObject.GetComponent<Renderer>().material = materialList[(int)value];
                tileTerrainType = value;
            }
            else {
                Debug.LogError("The material:" + Enum.GetName(typeof(eTerrainType), value) + " for " + gameObject.ToString() + " doesn't exist");
            }

        }
        get {
            return tileTerrainType;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
