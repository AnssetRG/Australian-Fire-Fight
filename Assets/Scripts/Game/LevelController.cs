using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FireGeneralController : MonoBehaviour
{
    private List<GameObject> FireList;
    public GameObject fireGameObj;
    private LevelData LevelDataObj;
    private int level;
    private List<float> spawnTimers;
    private float timeElapsed;
    float mayorSpawnTime;

    private void Awake()
    {
        FireList = new List<GameObject>();

        string levelData = JsonFileReader.LoadJsonAsResource("levels.json");
        LevelDataObj = JsonUtility.FromJson<LevelData>(levelData);

        level = 1; //se jala del menu okis playerprefs dud
        List<Fire> FireData = LevelDataObj.levels[level - 1].fires;

        spawnTimers = new List<float>();

        foreach (Fire data in FireData)
        {
            Vector3 position = new Vector3(data.x, data.y);
            GameObject newFire = Instantiate(fireGameObj, position, Quaternion.identity);
            newFire.GetComponent<FireController>().Life = data.life;
            newFire.GetComponent<FireController>().despawnTime = data.despawnTime;
            newFire.transform.localScale = new Vector3(data.scale, data.scale, 1);
            spawnTimers.Add(data.spawnTime);
            newFire.SetActive(false);
            FireList.Add(newFire);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0f;
        mayorSpawnTime = spawnTimers.Max();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        for (int i = 0; i < spawnTimers.Count; i++)
        {
            if (timeElapsed >= spawnTimers[i])
            {
                spawnTimers[i] = 999; //caquita
                FireList[i].SetActive(true);
            }
        }
        if (timeElapsed > mayorSpawnTime)
        {
            spawnTimers.Clear();
        }
    }
}
