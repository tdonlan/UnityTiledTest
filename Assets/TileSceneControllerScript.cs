﻿using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;

using Assets;

public class TileSceneControllerScript : MonoBehaviour {

    public TileMapData tileMapData;

    public string debugTextString;
    public Text debugText;
    public Text debugText2;

    public GameObject spritePrefab;
    public List<GameObject> boundingSpriteList = new List<UnityEngine.GameObject>();

	// Use this for initialization
	void Start () {
        setRefs();
        loadTileMapData();
	}

    private void setRefs()
    {
        debugText = GameObject.FindGameObjectWithTag("debugText").GetComponent<Text>();
        debugText2 = GameObject.FindGameObjectWithTag("debugText2").GetComponent<Text>();

        spritePrefab = Resources.Load<GameObject>("SpritePrefab");
    }

    private void loadTileMapData()
    {
        string outStr = "";
        var tileMapObject = GameObject.FindGameObjectWithTag("tileMap");
        tileMapData = new TileMapData(tileMapObject);
        foreach (var b in tileMapData.collisionBoundsList)
        {
            outStr += b + "\n";
            displayBoundingRect(b);
        }
        setDebugText2(outStr);
    }
    
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setDebugText2(string text)
    {
        this.debugText2.text = text;
    }

    public void setDebugText(string text)
    {
        this.debugText.text = text;
    }

    //display a sprite rectangle where bounds are
    //testing
    public void displayBoundingRect(Bounds b)
    {
        clearBoundingRect();
        GameObject bSprite = Instantiate(spritePrefab);
        bSprite.transform.position = b.center;
        var sprite = bSprite.GetComponent<Sprite>();
        var spriteRenderer = bSprite.GetComponent<SpriteRenderer>();
        

        boundingSpriteList.Add(bSprite);
       
    }

    private void clearBoundingRect()
    {
        foreach(var b in boundingSpriteList)
        {
            Destroy(b);
        }
        boundingSpriteList.Clear();
    }


}
