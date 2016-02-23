using UnityEngine;
using System.Collections;

//NOTE: Blocks of a board with 8x8 size will be from x=0 to x=11 (+2 for border) relative to the position of the board object in unity world space,
// same rule applied in y

//all blocks in a board is children of the board in hierarchy

public class TileGenerator : MonoBehaviour {

	public int boardWidth;
	public int boardLength;

	//board code for accessing the block inside this board, could be player's number
	public int boardCode;

	//Block Prefab
	[SerializeField] GameObject BlockPrefab;

	//Tile Initialization
	public void InitializeBoard(){
		Vector3 boardRootPosition = transform.position;
		for (int i = 0; i > -1*(boardLength+2); i--) {
			for (int j = 0; j < boardWidth+2; j++) {
				GameObject newBlock = (GameObject) Instantiate(BlockPrefab,boardRootPosition+new Vector3(j,0,i),new Quaternion());
				BlockData newBlockData = newBlock.GetComponent<BlockData> ();
				if (newBlockData != null) {
					newBlockData.x = j;
					newBlockData.y = i;
					if (i == 0 || i == -1*(boardWidth+1)) {
						newBlockData.GenerateBorderTiles ();
					} else if (j == 0 || j == boardLength + 1) {
						newBlockData.GenerateBorderTiles ();
					}
					else{
						newBlockData.GenerateTiles (1); //1 as dummy altitude
					}
				}
				newBlock.transform.SetParent (transform);
			}
		}	
	}

	void Start () {
		InitializeBoard ();
	}
}
