using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FireGeneralController : MonoBehaviour
{
    public static FireGeneralController instance;
    private List<GameObject> FireList;
    public GameObject fireGameObj;
    private LevelData LevelDataObj;
    private int level;
    private List<float> spawnTimers;
    private float timeElapsed;
    private float mayorSpawnTime;
    public int firesPutOut;
    private int firesToPutOut;

    private void Awake()
    {
        CreateSingleton();

        FireList = new List<GameObject>();

        string levelData = JsonFileReader.LoadJsonAsResource("levels.json");
        LevelDataObj = JsonUtility.FromJson<LevelData>(levelData);

        level = 2; //se jala del menu okis playerprefs dud
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

    void CreateSingleton() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0f;
        firesPutOut = 0;
        firesToPutOut = FireList.Count;
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

        if (firesPutOut == firesToPutOut) {
            GameController.instance.SetResult(true);
        }
       
        if (timeElapsed > mayorSpawnTime)
        {
            spawnTimers.Clear();
        }
        
    }
}
