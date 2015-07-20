using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

using Assets;

public class TileSceneControllerScript : MonoBehaviour {

    public TileMapData tileMapData;

    public string debugTextString;
    public Text debugText;
    public Text debugText2;

	// Use this for initialization
	void Start () {
        setRefs();
        loadTileMapData();
	}

    private void setRefs()
    {
        debugText = GameObject.FindGameObjectWithTag("debugText").GetComponent<Text>();
        debugText2 = GameObject.FindGameObjectWithTag("debugText2").GetComponent<Text>();
    }

    private void loadTileMapData()
    {
        string outStr = "";
        var tileMapObject = GameObject.FindGameObjectWithTag("tileMap");
        tileMapData = new TileMapData(tileMapObject);
        foreach (var b in tileMapData.collisionBoundsList)
        {
            outStr += b + "\n";
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


}
