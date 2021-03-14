using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInst : MonoBehaviour
{
    // Want to have an infinite number, but setting this for now
    public List<GameObject> spawnPool;
    public List<GameObject> renderPool;
    public GameObject quad;

    // Start is called before the first frame update
    void Start()
    {
        spawnObject();
    }

    public void spawnObject()
    {
        // Local vars
        int randomDrawing = 0;
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();
        float screenX, screenZ;
        Vector3 pos;
        // Choosing random object and starting coordinates
        randomDrawing = Random.Range(0, spawnPool.Count);
        toSpawn = spawnPool[randomDrawing];
        screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
        screenZ = Random.Range(c.bounds.min.z, c.bounds.max.z);
        pos = new Vector3(screenX, 0, screenZ);
        // Instantiating object, removing from spawnPool s.t. duplicates can be avoided
        Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        renderPool.Add(spawnPool[randomDrawing]);
        spawnPool.Remove(spawnPool[randomDrawing]);
    }

    private void destroyObjects()
    {
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Spawnable"))
        {
            Destroy(o);
        }
    }
}
