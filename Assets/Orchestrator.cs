using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Newtonsoft.Json;

public class Orchestrator : MonoBehaviour {
    public VoxelMap map;

    void Start() {
        ConfigManager.Init("Assets/config.json");

        string json = FileHandler.Read(ConfigManager.config.voxelMap.fileName);
        if (json != "") {
            map = JsonConvert.DeserializeObject<VoxelMap>(json);
        }

        map.CreateGameObjects();
    }
}

public class VoxelMap {
    public int width;
    public int height;
    public int depth;

    public List<List<List<Tile3D>>> tiles;

    public void CreateGameObjects() {
        for (int z = 0; z < tiles.Count; z++) {
            for (int y = 0; y < tiles[z].Count; y++) {
                for (int x = 0; x < tiles[z][y].Count; x++) {
                    tiles[z][y][x].CreateGameObject();
                }
            }
        }
    }
}

public class Tile3D {
    public int posX;
    public int posY;
    public int posZ;

    public TileTypes type;

    public void CreateGameObject() {
        if (type == TileTypes.VOID) {
            return;
        }

        Vector3 pos = new Vector3(0.8f * posX, 0.8f * posZ, 0.8f * posY);
        Quaternion rot = Quaternion.identity;
        //rot *= Quaternion.Euler(-90, 0, 0);
        Instantiator.InstantiateGameObject(GetPrefabString(), pos, rot);
    }

    public string GetPrefabString() {
        switch (type) {
            case TileTypes.SOIL:
                return "Prefabs/Soil";
            case TileTypes.GRASS:
                return "Prefabs/Grass";
            case TileTypes.SAND:
                return "Prefabs/Sand";
            case TileTypes.WATER:
                return "Prefabs/Water";
        }
        return "";
    }
}

public enum TileTypes {
    VOID = 0,
    SOIL = 1,
    GRASS = 2,
    SAND = 3,
    WATER = 4
}

