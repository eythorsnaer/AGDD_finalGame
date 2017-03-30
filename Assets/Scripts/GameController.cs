using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject currentLevel;
    private GameData data;
    private int numberOfLevelsInGame = 16;

	void Start()
    {
		Load();
    }

    public void Save()
    {
		BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameProgress.dat");

		if (currentLevel != null) 
		{
			LevelController currentLevelController = currentLevel.GetComponent<LevelController> ();
			LevelData level = new LevelData ();

			level.ID = currentLevelController.getID ();

			data.levels [level.ID].hasBeenCompleted = currentLevelController.getHasBeenCompleted ();
			data.levels [level.ID].hasMapPiece = currentLevelController.gethasMapPiece ();
			data.levels [level.ID].mapPieceWasFound = currentLevelController.getMapPieceFound ();
		} 

        bf.Serialize(file, data);
        file.Close();
    }

	public int getCurrentLevelIndex()
	{
		if (currentLevel == null) 
		{
			Debug.Log ("SOMETHING THAT SHOULDN'T HAVE HAPPENED HAPPENED - CHECK GAME MANAGER");
			return -1;
		} 
		else 
		{
			return currentLevel.GetComponent<LevelController> ().getID ();
		}
	}

	public void loadSceneByIndex(int i) {
		SceneManager.LoadScene (i);
	}

	public LevelData getLevel()
	{
		if (data == null) 
		{
			LevelData level = new LevelData ();
			level.ID = 0;
			level.hasBeenCompleted = false;
			level.hasMapPiece = false;
			level.mapPieceWasFound = false;
			return level;
		}
		return data.levels [currentLevel.GetComponent<LevelController> ().getID()];
	}

	public List<LevelData> getLevels()
	{
		if (data == null) 
		{
			Load();
		}
		return data.levels;
	}

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/gameProgress.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameProgress.dat", FileMode.Open);
            data = (GameData)bf.Deserialize(file);
            file.Close();
		}
        else
        {
            initializeGameData();
        }
    }

    public void initializeGameData()
    {
		data = new GameData();
        data.levels = new List<LevelData>();
        
        for (int i = 0; i < numberOfLevelsInGame; i++)
        {
            LevelData level = new LevelData();
            level.init(i);
            data.levels.Add(level);
        }

        Save();
    }
}

[Serializable]
public class GameData
{
    public List<LevelData> levels;
} 

[Serializable]
public class LevelData
{
    public int ID;
    public bool hasBeenCompleted;
    public bool hasMapPiece;
    public bool mapPieceWasFound;

    public void init(int ID)
    {
        this.ID = ID;
        hasBeenCompleted = false;
        mapPieceWasFound = false;
    }
}