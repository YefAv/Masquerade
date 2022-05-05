using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlidingPuzzleLogic : MonoBehaviour {
	public int Height = 3;
	public int Width = 3;
	public float SeperationBetweenTiles = 0.5f;
	public GameObject Tile;
	[SerializeField] GameObject[] tiles;
	private GameObject[,] TileDisplayArray;
	public bool Complete = false;
	[SerializeField] private GameObject jail;

	[SerializeField] AudioClip winClip;
	AudioSource audioSource;
	[SerializeField] ParticleSystem winParticles;

	void Start() {
		CreatePuzzleTiles();

		StartCoroutine(JugglePuzzle());

		audioSource = GetComponent<AudioSource>();
	}
	public Vector3 GetTargetLocation(Tile thisTile) {    //lo que me dice la posicion de los cubos
		Tile MoveTo = CheckIfWeCanMove((int)thisTile.GridLocation.x, (int)thisTile.GridLocation.y, thisTile);
		if (MoveTo != thisTile)
		{
			Vector3 TargetPos = MoveTo.TargetPosition;
			Vector2 GridLocation = thisTile.GridLocation;
			thisTile.GridLocation = MoveTo.GridLocation;

			MoveTo.LaunchPositionCoroutine(thisTile.TargetPosition);
			MoveTo.GridLocation = GridLocation;

			return TargetPos;
		}
		return thisTile.TargetPosition;
	}
	private Tile CheckMoveLeft(int Xpos, int Ypos, Tile thisTile) {   
		if ((Xpos - 1) >= 0)
		{
			return GetTileAtThisGridLocation(Xpos - 1, Ypos, thisTile);
		}
		return thisTile;
	}
	private Tile CheckMoveRight(int Xpos, int Ypos, Tile thisTile) {
		if ((Xpos + 1) < Width)
		{
			return GetTileAtThisGridLocation(Xpos + 1, Ypos, thisTile);
		}
		return thisTile;
	}
	private Tile CheckMoveDown(int Xpos, int Ypos, Tile thisTile) {
		if ((Ypos - 1) >= 0)
		{
			return GetTileAtThisGridLocation(Xpos, Ypos - 1, thisTile);
		}
		return thisTile;
	}
	private Tile CheckMoveUp(int Xpos, int Ypos, Tile thisTile) {
		if ((Ypos + 1) < Height)
		{
			return GetTileAtThisGridLocation(Xpos, Ypos + 1, thisTile);
		}
		return thisTile;
	}
	private Tile CheckIfWeCanMove(int Xpos, int Ypos, Tile thisTile) {    //hasta aqui y los ultimos son los que me dicen que se estan moviendo en las posiciones adecuadas

		if (CheckMoveLeft(Xpos, Ypos, thisTile) != thisTile)
		{
			return CheckMoveLeft(Xpos, Ypos, thisTile);
		}
		if (CheckMoveRight(Xpos, Ypos, thisTile) != thisTile)
		{
			return CheckMoveRight(Xpos, Ypos, thisTile);
		}
		if (CheckMoveDown(Xpos, Ypos, thisTile) != thisTile)
		{
			return CheckMoveDown(Xpos, Ypos, thisTile);
		}
		if (CheckMoveUp(Xpos, Ypos, thisTile) != thisTile)
		{
			return CheckMoveUp(Xpos, Ypos, thisTile);
		}
		return thisTile;
	}
	private Tile GetTileAtThisGridLocation(int x, int y, Tile thisTile) {
		for (int j = Height - 1; j >= 0; j--)
		{
			for (int i = 0; i < Width; i++)
			{
				if ((TileDisplayArray[i, j].GetComponent<Tile>().GridLocation.x == x) &&
				   (TileDisplayArray[i, j].GetComponent<Tile>().GridLocation.y == y))
				{
					if (TileDisplayArray[i, j].GetComponent<Tile>().Active == false)
					{
						return TileDisplayArray[i, j].GetComponent<Tile>();
					}
				}
			}
		}
		return thisTile;
	}
	public IEnumerator CheckForComplete() {
		while (Complete == false)
		{
			Complete = true;
			for (int j = Height - 1; j >= 0; j--)
			{
				for (int i = 0; i < Width; i++)
				{
					if (TileDisplayArray[i, j].GetComponent<Tile>().CorrectLocation == false)
					{
						Complete = false;
					}
				}
			}
			yield return null;
		}
		if (Complete)
		{
			//WinConditionTemp.winConditionCode.SolvePuzzle();
			Debug.Log("terminadio");
			audioSource.clip = winClip;
			audioSource.Play();
			winParticles.Play();
			jail.SetActive(false); //Animación de bajar celda
			//Ganaste rey
		}
		yield return null;
	}
	private void CreatePuzzleTiles() {
		TileDisplayArray = new GameObject[Width, Height];
		int TileValue = 0;
		for (int j = Height - 1; j >= 0; j--)
		{
			for (int i = 0; i < Width; i++)
			{
				TileDisplayArray[i, j] = tiles[TileValue];

				Tile thisTile = TileDisplayArray[i, j].GetComponent<Tile>();
				thisTile.ArrayLocation = new Vector2(i, j);
				thisTile.GridLocation = new Vector2(i, j);
				TileValue++;
			}
		}
	}
	private IEnumerator JugglePuzzle() {
		yield return new WaitForSeconds(1.0f);
		TileDisplayArray[0, 0].GetComponent<Tile>().Active = false;
		yield return new WaitForSeconds(1.0f);
		for (int k = 0; k < 20; k++)
		{
			for (int j = 0; j < Height; j++)
			{
				for (int i = 0; i < Width; i++)
				{
					// attempt to execute a move for this tile.
					TileDisplayArray[i, j].GetComponent<Tile>().ExecuteAdditionalMove();

					yield return new WaitForSeconds(0.02f);
				}
			}
		}
		StartCoroutine(CheckForComplete());
		yield return null;
	}
}
