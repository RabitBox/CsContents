using UnityEngine;

/// <summary>
/// JsonUtilityを使用したデータ管理クラス。
/// </summary>
public class JsonDataManager
{
	/// <summary>
	/// Json形式に変換して保存する。
	/// </summary>
	/// <typeparam name="T">保存するデータクラス。</typeparam>
	/// <param name="content">保存するデータ。</param>
	/// <param name="fileName">保存するデータ名。</param>
	public static void Save<T>(T content, string fileName = "save.dat")
		where T : class
	{
		SaveManager.Save(JsonUtility.ToJson(content), fileName);
	}

	/// <summary>
	/// Json形式に変換して読み込む。
	/// </summary>
	/// <typeparam name="T">読み込むデータクラス。</typeparam>
	/// <param name="fileName">読み込むデータ名。</param>
	/// <returns>読み込んだデータ。</returns>
	public static T Load<T>(string fileName = "save.dat")
		where T : class
	{
		return JsonUtility.FromJson<T>(SaveManager.Load(fileName));
	}
}
