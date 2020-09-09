using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
{
    public enum BlockType {Dirt, Grass, Stone, Air}

    public Vector3 position;
    public BlockType blockType;
    private Chunk chunkInstance;
    GameObject cube;

    private bool isRendered = false;

    private GameObject planeTop;
    private GameObject planeBottom;
    private GameObject[] planeX = new GameObject[2];
    private GameObject[] planeZ = new GameObject[2];

    public bool isPlaneTop = true;
    public bool isPlaneBottom = true;
    public bool[] isPlaneX = { true, true };
    public bool[] isPlaneZ = { true, true };

    public Block(Vector3 pos, BlockType blockType, Chunk chunkInstance)
    {
        this.position = pos;
        this.blockType = blockType;
        this.chunkInstance = chunkInstance;
    }

    public void Render(GameObject chunk)
    {
        GameObject blockGameObject = new GameObject();
        blockGameObject.name = "Block";
        blockGameObject.transform.SetParent(chunk.transform);
        int scopeBlockNumber;

        scopeBlockNumber = Convert.ToInt32(this.position.x) + 1;
        if (scopeBlockNumber < chunkInstance.blocks.GetLength(1) - 1 && scopeBlockNumber >= 0 &&chunkInstance.GetBlockType(Convert.ToInt32(this.position.x) + 1, Convert.ToInt32(this.position.y), Convert.ToInt32(this.position.z)) != Block.BlockType.Grass)
        {
            Debug.Log(1);
            planeX[0] = GameObject.CreatePrimitive(PrimitiveType.Plane);
            planeX[0].name = "PlaneX - 0";
            planeX[0].transform.position = this.position + new Vector3(0f, 0.5f, 0f);
            planeX[0].transform.SetParent(blockGameObject.transform);
            planeX[0].transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
        }

        scopeBlockNumber = Convert.ToInt32(this.position.x) - 1;
        if (scopeBlockNumber < chunkInstance.blocks.GetLength(1) - 1 && scopeBlockNumber >= 0 && chunkInstance.GetBlockType(Convert.ToInt32(this.position.x) - 1, Convert.ToInt32(this.position.y), Convert.ToInt32(this.position.z)) != Block.BlockType.Grass)
        {
            Debug.Log(2);
            planeX[1] = GameObject.CreatePrimitive(PrimitiveType.Plane);
            planeX[1].name = "PlaneX - 1";
            planeX[1].transform.position = this.position + new Vector3(0f, 0.5f, 0f);
            planeX[1].transform.SetParent(blockGameObject.transform);
            planeX[1].transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
        }

        scopeBlockNumber = Convert.ToInt32(this.position.y) + 1;
        if (scopeBlockNumber < chunkInstance.blocks.GetLength(2) - 1 && scopeBlockNumber >= 0 && chunkInstance.GetBlockType(Convert.ToInt32(this.position.x), Convert.ToInt32(this.position.y) + 1, Convert.ToInt32(this.position.z)) != Block.BlockType.Grass)
        {
            Debug.Log(3);
            planeTop = GameObject.CreatePrimitive(PrimitiveType.Plane);
            planeTop.name = "PlaneTop";
            planeTop.transform.position = this.position + new Vector3(0f, 0.5f, 0f);
            planeTop.transform.SetParent(blockGameObject.transform);
            planeTop.transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
        }

        scopeBlockNumber = Convert.ToInt32(this.position.y) - 1;
        if (scopeBlockNumber < chunkInstance.blocks.GetLength(2) - 1 && chunkInstance.GetBlockType(Convert.ToInt32(this.position.x), Convert.ToInt32(this.position.y) - 1, Convert.ToInt32(this.position.z)) != Block.BlockType.Grass)
        {
            Debug.Log(4);
            planeBottom = GameObject.CreatePrimitive(PrimitiveType.Plane);
            planeBottom.name = "PlaneBottom";
            planeBottom.transform.position = this.position + new Vector3(0f, 0.5f, 0f);
            planeBottom.transform.SetParent(blockGameObject.transform);
            planeBottom.transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
        }

        scopeBlockNumber = Convert.ToInt32(this.position.z) - 1;
        if (scopeBlockNumber < chunkInstance.blocks.GetLength(3) - 1 && scopeBlockNumber >= 0 && chunkInstance.GetBlockType(Convert.ToInt32(this.position.z), Convert.ToInt32(this.position.y), Convert.ToInt32(this.position.z) - 1) != Block.BlockType.Grass)
        {
            Debug.Log(5);
            planeZ[1] = GameObject.CreatePrimitive(PrimitiveType.Plane);
            planeZ[1].name = "PlaneZ - 1";
            planeZ[1].transform.position = this.position + new Vector3(0f, 0.5f, 0f);
            planeZ[1].transform.SetParent(blockGameObject.transform);
            planeZ[1].transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
        }

        scopeBlockNumber = Convert.ToInt32(this.position.z) + 1;
        if (scopeBlockNumber < chunkInstance.blocks.GetLength(3) - 1 && scopeBlockNumber >= 0 && chunkInstance.GetBlockType(Convert.ToInt32(this.position.z), Convert.ToInt32(this.position.y), Convert.ToInt32(this.position.z) + 1) != Block.BlockType.Grass)
        {
            Debug.Log(6);
            planeZ[1] = GameObject.CreatePrimitive(PrimitiveType.Plane);
            planeZ[1].name = "PlaneZ - 1";
            planeZ[1].transform.position = this.position + new Vector3(0f, 0.5f, 0f);
            planeZ[1].transform.SetParent(blockGameObject.transform);
            planeZ[1].transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
        }

        //this.cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //this.cube.transform.position = position;

    }

    public BlockType GetBlockType()
    {
        return this.blockType;
    }

}
