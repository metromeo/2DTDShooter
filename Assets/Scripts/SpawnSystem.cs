using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SpawnItem {
    [SerializeField] private GameObject prefab;
    [SerializeField] private float spawnDelay;
    public float CurrDelay { get; set; }
    public GameObject GetPrefab() => prefab;
    public void UpdateCurrDelay() => CurrDelay = Time.realtimeSinceStartup + spawnDelay;

}

public class SpawnSystem : MonoBehaviour {
    [SerializeField] private SpawnItem[] spawnItems;
    [SerializeField] private Vector2 minMaxSpawnDistance;
    private Transform cam;

    private void Start() {
        cam = Referencer.Get<CameraControl>().GetCamera().transform;
    }

    private void Update() {
        for (int i = 0; i < spawnItems.Length; i++) {
            if (Time.realtimeSinceStartup > spawnItems[i].CurrDelay){
                SpawnItem(spawnItems[i].GetPrefab());
                spawnItems[i].UpdateCurrDelay();
            }
        }
    }

    void SpawnItem(GameObject obj) {
        Instantiate(obj, GetRandomPos(), Quaternion.identity);
    }


    Vector3 GetRandomPos() {
        float x = Random.Range(minMaxSpawnDistance.x, minMaxSpawnDistance.y);
        float z = Random.Range(minMaxSpawnDistance.x, minMaxSpawnDistance.y);
        x *= Random.Range(0f, 1f) > 0.5f ? 1 : -1;
        z *= Random.Range(0f, 1f) > 0.5f ? 1 : -1;
        Vector3 pos = new Vector3(cam.position.x + x, 0, cam.position.z + z);
        return pos;
    }

}
