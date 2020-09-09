using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{

    List<Chunk> map = new List<Chunk>();
    GameObject world;

    // Start is called before the first frame update
    void Start()
    {
        world = this.transform.gameObject;

        map.Add(new Chunk(new Vector2(0, 0), world));

        foreach (Chunk chunk in map)
        {
            chunk.Render(world);
        }
    }

    void BuildChunk(int posX, int posZ)
    {
        if (posX % 16 != 0 || posZ % 16 != 0) return;


    }
}
