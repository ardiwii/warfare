using UnityEngine;
using System.Collections;

public class BlockData : MonoBehaviour {

	//height of the block, represented by the number of children tiles, stacked in the block, >=0, 0 means water tile
	public int altitude;

	//the object on the block, the object contained in a block is placed as the last child of that block.
	public GameObject contains;

	//block x and y coordinate in the board
	public int x;
	public int y;

	//tile prefabs
	[SerializeField] private GameObject waterTile;
	[SerializeField] private GameObject grassTile;
	[SerializeField] private GameObject borderTile;

	//the height difference between stacked tiles
	private float deltaY = 0.2f;

	// Use this for initialization
	void Start () {
	}

	//Generate tiles with default altitude, for non default altitude, use only if altitude has been set manually before calling this method
	public void GenerateTiles(){
		if (altitude == 0) {
			GameObject newTile = (GameObject) Instantiate (waterTile,transform.position,new Quaternion());
			newTile.transform.SetParent (transform);
		}
		else{
			for (int i = 1; i <= altitude; i++) {
				GameObject newTile = (GameObject) Instantiate (grassTile,new Vector3(transform.position.x,transform.position.y+(i-1)*deltaY,transform.position.z),new Quaternion());
				newTile.transform.SetParent (transform);
			}
		}
	}

	//Generate tiles according to altitude set in alt parameter
	public void GenerateTiles(int alt){
		altitude = alt;
		if (altitude == 0) {
			GameObject newTile = (GameObject) Instantiate (waterTile,transform.position,new Quaternion());
			newTile.transform.SetParent (transform);
		}
		else{
			for (int i = 1; i <= altitude; i++) {
				GameObject newTile = (GameObject) Instantiate (grassTile,new Vector3(transform.position.x,transform.position.y+(i-1)*deltaY,transform.position.z),new Quaternion());
				newTile.transform.SetParent (transform);
			}
		}
	}

	//Generate border tiles
	public void GenerateBorderTiles(){
		if (altitude == 0) {
			GameObject newTile = (GameObject) Instantiate (borderTile,transform.position,new Quaternion());
			newTile.transform.SetParent (transform);
		}
		else{
			for (int i = 1; i <= altitude; i++) {
				GameObject newTile = (GameObject) Instantiate (borderTile,new Vector3(transform.position.x,transform.position.y+(i-1)*deltaY,transform.position.z),new Quaternion());
				newTile.transform.SetParent (transform);
			}
		}
	}

	//PUBLIC METHOD FOR UNIT MOVEMENT
	public void InsertObject(){
	
	}
}
