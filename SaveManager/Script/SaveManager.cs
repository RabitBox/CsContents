using System.IO;
using UnityEngine;

/// <summary>
/// セーブ、ロードを行うクラス。
/// </summary>
public class SaveManager
{
	/// <summary>
	/// 渡したデータをセーブする。
	/// </summary>
	/// <param name="content">保存するデータ。</param>
	/// <param name="fileName">データを保存するファイル名。</param>
	public static void Save(string content, string fileName = "save.dat")
	{
		File.WriteAllText(Path.Combine(Application.persistentDataPath, fileName), content);
	}

	/// <summary>
	/// セーブしたデータを読み込む。
	/// </summary>
	/// <param name="fileName">保存したデータ名。</param>
	/// <returns>読み込んだデータ。</returns>
	public static string Load(string fileName = "save.dat")
	{
		return File.ReadAllText(Path.Combine(Application.persistentDataPath, fileName));
	}
}
