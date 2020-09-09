using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
    public const int chunkWidth = 16;
    public const int chunkHeight = 64;

    public Block[,,] blocks = new Block[chunkWidth, chunkHeight, chunkWidth];
    public GameObject chunk;
    public Vector2 position;
    public Chunk chunkInstance;

    public Chunk(Vector2 pos, GameObject world)
    {
        this.chunk = new GameObject();
        this.chunk.transform.SetParent(world.transform);
        this.chunk.name = "Chunk";
        this.position = pos;
        this.chunkInstance = this;

        for (int x = 0; x < chunkWidth; x++)
        {
            for (int y = 0; y < chunkHeight; y++)
            {
                for (int z = 0; z < chunkWidth; z++)
                {
                    Vector3 newCube = new Vector3(x + (this.position.x * 16), y, z + (this.position.y * 16));
                    blocks[x ,y ,z] = new Block(newCube, Block.BlockType.Grass, chunkInstance);
                }
            }
        }
    }

    public void Render(GameObject world)
    {
        for (int z = 0; z < blocks.GetLength(0); z++)
        {
            for (int y = 0; y < blocks.GetLength(1); y++)
            {
                for (int x = 0; x < blocks.GetLength(2); x++)
                {
                    //GameObject rowX = new GameObject();
                    //rowX.transform.SetParent(this.chunk.transform);

                    blocks[x, y, z].Render(chunk);
                }
            }
        }
    }

    public void Abolish()
    {
        WorldGeneration.Destroy(chunk);
    }

    public Block.BlockType GetBlockType(int x, int y, int z)
    {
        if (y < 0) return Block.BlockType.Air;

        Block block = blocks[x, y, z];
        Block.BlockType blockType = block.GetBlockType();

        return blockType;
    }

    public int GetChunkWidth()
    {
        return chunkWidth;
    }

    public int GetChunkHeight()
    {
        return chunkHeight;
    }
}
