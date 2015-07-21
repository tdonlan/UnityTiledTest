using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {

    private float speed = .05f;
    private float moveAmt = 0.5f;

    private bool canMove = true;

    private Rect playerRect;
    private Bounds playerBounds;

    private TileSceneControllerScript tileSceneScript;
    
	// Use this for initialization
	void Start () {
        setRefs();
        setPlayerRect();
	}

    private void setRefs()
    {
        this.tileSceneScript = GameObject.FindObjectOfType<TileSceneControllerScript>().GetComponent<TileSceneControllerScript>();

    }

    private void setPlayerRect()
    {
        var box2d = this.gameObject.GetComponent<BoxCollider2D>();
        playerBounds = box2d.bounds;
        playerRect = new Rect(gameObject.transform.position.x + box2d.offset.x, gameObject.transform.position.y
             + box2d.offset.y, box2d.size.x, box2d.size.y);

        tileSceneScript.displayBoundingRect(playerBounds);
    }


	// Update is called once per frame
	void Update () {

        setPlayerRect();
        tileSceneScript.setDebugText(playerBounds.ToString());

        float moveY=0.0f;
        float moveX=0.0f;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            canMove = false;
            moveX = -moveAmt;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            canMove = false;
            moveX = moveAmt;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            canMove = false;
            moveY = moveAmt;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            canMove = false;
            moveY = -moveAmt;
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow)){
            canMove = true;
        }
        if(Input.GetKeyUp(KeyCode.RightArrow)){
             canMove = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            canMove = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            canMove = true;
        }

    
        var pos = this.gameObject.transform.position;

        var newPos = new Vector3(pos.x + moveX, pos.y + moveY);
        if (!checkCollision(getNewBounds(newPos)))
        {
            this.gameObject.transform.position = newPos;
        }
     
       
	}

    private Bounds getNewBounds(Vector3 newPos)
    {
        Bounds newBounds = playerBounds;
        newBounds.center = newPos;
        return newBounds;

    }

    private bool checkCollision(Bounds bounds)
    {
        return tileSceneScript.tileMapData.checkCollision(bounds);
    }
}
