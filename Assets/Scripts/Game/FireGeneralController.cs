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
    private float actual_wait_time;

    private void Awake()
    {
        CreateSingleton();

        if (PlayerPrefs.GetInt("level") == 4)
        {
            return;
        }

        FireList = new List<GameObject>();

        string levelData = JsonFileReader.LoadJsonAsResource("levels.json");
        LevelDataObj = JsonUtility.FromJson<LevelData>(levelData);

        List<Fire> FireData = LevelDataObj.levels[PlayerPrefs.GetInt("level") - 1].fires;

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

    void CreateSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0f;
        firesPutOut = 0;
        if (PlayerPrefs.GetInt("level") == 4)
        {
            InstantiateRandomFire();
            return;
        }
        firesToPutOut = FireList.Count;
        mayorSpawnTime = spawnTimers.Max();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (PlayerPrefs.GetInt("level") == 4)
        {
            if (timeElapsed >= actual_wait_time)
                InstantiateRandomFire();
        }
        else
        {
            SetFire();
        }

    }

    void SetFire()
    {
        for (int i = 0; i < spawnTimers.Count; i++)
        {
            if (timeElapsed >= spawnTimers[i])
            {
                spawnTimers[i] = 999; //caquita
                FireList[i].SetActive(true);
            }
        }

        if (firesPutOut == firesToPutOut)
        {
            GameController.instance.SetResult(true);
        }

        if (timeElapsed > mayorSpawnTime)
        {
            spawnTimers.Clear();
        }
    }

    void InstantiateRandomFire()
    {
        GameObject newFire = Instantiate(fireGameObj, RandomPosition(), Quaternion.identity);
        newFire.GetComponent<FireController>().Life = Random.Range(2, 10);
        newFire.GetComponent<FireController>().despawnTime = Random.Range(25, 50);
        float scale_t = Random.Range(1, 5);
        newFire.transform.localScale = new Vector3(scale_t, scale_t, 1);
        actual_wait_time = Random.Range(5, 10);
    }

    Vector3 RandomPosition()
    {
        float x = Random.Range(-35, 35);
        float y = Random.Range(-10, 20);
        return new Vector3(x, y, 0);
    }

    public void FireEliminated()
    {
        firesPutOut++;
        GameController.instance.FireOutMessage(true);
    }
}
