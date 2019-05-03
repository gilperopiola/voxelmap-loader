public static class ConfigManager {
    public static Config config;

    public static void Init(string fileName) {
        config = UnityEngine.JsonUtility.FromJson<Config>(FileHandler.Read(fileName));
    }

    [System.Serializable]
    public class Config {
        public string projectName;
        public VoxelMapConfig voxelMap;
    }

    [System.Serializable]
    public class VoxelMapConfig {
        public string fileName;
    }
}
