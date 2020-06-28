using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class LevelData {
    public List<Level> levels;
}

[System.Serializable]
public class Level {
    public int level;
    public List<Fire> fires;
}

[System.Serializable]
public class Fire {
    public int life;
    public float scale;
    public float x;
    public float y;
    public float spawnTime;
    public float despawnTime;
}
