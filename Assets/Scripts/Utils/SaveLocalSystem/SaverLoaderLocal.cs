using System.Collections;
using UnityEngine;


public class SaverLoaderLocal : MonoBehaviour
{
	public static SaverLoaderLocal Instance { get; private set; }


	private void Awake()
	{
		if (Instance != null)
		{
			GameObject.Destroy(this.gameObject);
		}

		Instance = this;
		DontDestroyOnLoad(this);
	}




	//--------------------------------------------------------CLEAR-------------------------------------------------------------------


	/// <summary>
	/// Отчистка сохранений
	/// </summary>
	public void ClearSavedData()
	{
		PlayerPrefs.DeleteAll();
	}


	/// <summary>
	/// Отчистка сохранений
	/// </summary>
	/// <param name="key"> ключ </param>
	public void ClearSavedData(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}


	/// <summary>
	/// Отчистка сохранений
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <param name="username"> имя пользователя </param>
	public void ClearSavedData(string key, string username)
	{
		var bufKey = key + ":" + username;
		PlayerPrefs.DeleteKey(bufKey);
	}







	//------------------------------------------------------------CHECK---------------------------------------------------------------



	/// <summary>
	/// Проверить, сохранён ли ключ
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <returns> true- было сохранение, false - ещё нет </returns>
	public bool CheckKey(string key)
	{
		return PlayerPrefs.HasKey(key);
	}


	/// <summary>
	/// Проверить, сохранён ли ключ
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <param name="username"> имя игрока </param>
	/// <returns> true- было сохранение, false - ещё нет </returns>
	public bool CheckKey(string key, string username)
	{
		var bufKey = key + ":" + username;
		return CheckKey(bufKey);
	}








	//-----------------------------------------------------SAVE-------------------------------------------------------





	/// <summary>
	/// Сохранить значение float в память по ключу 
	/// </summary>
	/// <param name="value"> значение </param>
	/// <param name="key"> ключ </param>
	public void SaveFloat(float value, string key)
	{
		PlayerPrefs.SetFloat(key, value);
		PlayerPrefs.Save();
	}


	/// <summary>
	/// Сохранить значение float в память по ключу и имени пользователя
	/// </summary>
	/// <param name="value"> значение </param>
	/// <param name="key"> ключ </param>
	/// <param name="username"> имя пользователя </param>
	public void SaveFloat(float value, string key, string username)
	{
		var bufKey = key + ":" + username;
		SaveFloat(value, bufKey);
	}


	/// <summary>
	/// Сохранить значение int в память по ключу 
	/// </summary>
	/// <param name="value"> значение </param>
	/// <param name="key"> ключ </param>
	public void SaveInt(int value, string key)
	{
		PlayerPrefs.SetInt(key, value);
		PlayerPrefs.Save();
	}


	/// <summary>
	/// Сохранить значение int в память по ключу и имени пользователя
	/// </summary>
	/// <param name="value"> значение </param>
	/// <param name="key"> ключ </param>
	/// <param name="username"> имя пользователя </param>
	public void SaveInt(int value, string key, string username)
	{
		var bufKey = key + ":" + username;
		SaveInt(value, bufKey);
	}


	/// <summary>
	/// Сохранить значение string в память по ключу 
	/// </summary>
	/// <param name="value"> значение </param>
	/// <param name="key"> ключ </param>
	public void SaveString(string value, string key)
	{
		PlayerPrefs.SetString(key, value);
		PlayerPrefs.Save();
	}


	/// <summary>
	/// Сохранить значение int в память по ключу и имени пользователя
	/// </summary>
	/// <param name="value"> значение </param>
	/// <param name="key"> ключ </param>
	/// <param name="username"> имя пользователя </param>
	public void SaveString(string value, string key, string username)
	{
		var bufKey = key + ":" + username;
		SaveString(value, bufKey);
	}







	//------------------------------------------LOAD---------------------------------------------------------------------------



	/// <summary>
	/// Загрузить значение float
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <returns> значение </returns>
	public float LoadFloat(string key)
	{
		return PlayerPrefs.GetFloat(key);
	}


	/// <summary>
	/// Загрузить значение float
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <param name="username"> имя пользователя </param>
	/// <returns> значение </returns>
	public float LoadFloat(string key, string username)
	{
		var bufKey = key + ":" + username;
		return LoadFloat(bufKey);
	}


	/// <summary>
	/// Загрузить значение int
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <returns> значение </returns>
	public int LoadInt(string key)
	{
		return PlayerPrefs.GetInt(key);
	}


	/// <summary>
	/// Загрузить значение int
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <param name="username"> имя пользователя </param>
	/// <returns> значение </returns>
	public int LoadInt(string key, string username)
	{
		var bufKey = key + ":" + username;
		return LoadInt(bufKey);
	}


	/// <summary>
	/// Загрузить значение string
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <returns> значение </returns>
	public string LoadString(string key)
	{
		return PlayerPrefs.GetString(key);
	}


	/// <summary>
	/// Загрузить значение string
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <param name="username"> имя пользователя </param>
	/// <returns> значение </returns>
	public string LoadString(string key, string username)
	{
		var bufKey = key + ":" + username;
		return LoadString(bufKey);
	}






	//-------------------------------------------TRYLOAD------------------------------------------------------------



	/// <summary>
	/// Загрузить значение float по ключу и вывести ошибку, если была
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <param name="value"> значение </param>
	/// <param name="error"> ошибка. Если ошибки не было, будет null </param>
	/// <returns> True - удалось </returns>
	public bool TryLoadFloat(string key, out float value, out string error)
	{
		error = null;

		if (!PlayerPrefs.HasKey(key))
		{
			error = "Hasn't that key for saving: " + key + "!";
			Debug.Log(error);
			value = 0.0f;
			return false;
		}

		value = PlayerPrefs.GetFloat(key);
		return true;
	}


	/// <summary>
	/// Загрузить значение float по ключу и имени пользователя и вывести ошибку, если была
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <param name="username"> имя пользователя </param>
	/// <param name="value"> значение </param>
	/// <param name="error"> ошибка. Если ошибки не было, будет null </param>
	/// <returns> True - удалось </returns>
	public bool TryLoadFloat(string key, string username, out float value, out string error)
	{
		var bufKey = key + ":" + username;
		return TryLoadFloat(bufKey, out value, out error);
	}


	/// <summary>
	/// Загрузить значение int по ключу и вывести ошибку, если была
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <param name="value"> значение </param>
	/// <param name="error"> ошибка. Если ошибки не было, будет null </param>
	/// <returns> True - удалось </returns>
	public bool TryLoadInt(string key, out int value, out string error)
	{
		error = null;

		if (!PlayerPrefs.HasKey(key))
		{
			error = "Hasn't that key for saving: " + key + "!";
			Debug.Log(error);
			value = 0;
			return false;
		}

		value = PlayerPrefs.GetInt(key);
		return true;
	}


	/// <summary>
	/// Загрузить значение int по ключу и имени пользователя и вывести ошибку, если была
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <param name="username"> имя пользователя </param>
	/// <param name="value"> значение </param>
	/// <param name="error"> ошибка. Если ошибки не было, будет null </param>
	/// <returns> True - удалось </returns>
	public bool TryLoadInt(string key, string username, out int value, out string error)
	{
		var bufKey = key + ":" + username;
		return TryLoadInt(key, out value, out error);
	}


	/// <summary>
	/// Загрузить значение string по ключу и вывести ошибку, если была
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <param name="value"> значение </param>
	/// <param name="error"> ошибка. Если ошибки не было, будет null </param>
	/// <returns> True - удалось </returns>
	public bool TryLoadString(string key, out string value, out string error)
	{
		error = null;

		if (!PlayerPrefs.HasKey(key))
		{
			error = "Hasn't that key for saving: " + key + "!";
			Debug.Log(error);
			value = "";
			return false;
		}

		value = PlayerPrefs.GetString(key);
		return true;
	}


	/// <summary>
	/// Загрузить значение string по ключу и имени пользователя и вывести ошибку, если была
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <param name="username"> имя пользователя </param>
	/// <param name="value"> значение </param>
	/// <param name="error"> ошибка. Если ошибки не было, будет null </param>
	/// <returns> True - удалось </returns>
	public bool TryLoadString(string key, string username, out string value, out string error)
	{
		var bufKey = key + ":" + username;
		return TryLoadString(key, out value, out error);
	}
}