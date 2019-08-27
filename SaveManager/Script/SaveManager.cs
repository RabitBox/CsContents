using System.IO;
using UnityEngine;

/// <summary>
/// セーブ、ロードを行うクラス。
/// </summary>
public class SaveManager
{
	//--------------------------------------------------
	// Save Methods
	//--------------------------------------------------
	/// <summary>
	/// 渡した文字列を保存する。
	/// </summary>
	/// <param name="content">保存するデータ。</param>
	/// <param name="fileName">保存するファイル名。</param>
	public static void Save(string content, string fileName = "save.dat")
	{
		File.WriteAllText(Path.Combine(Application.persistentDataPath, fileName), content);
	}

	/// <summary>
	/// 文字列配列を行毎に保存する。
	/// </summary>
	/// <param name="contents">保存するデータ配列。</param>
	/// <param name="fileName">保存するファイル名。</param>
	public static void SaveLines(string[] contents, string fileName = "save.dat")
	{
		File.WriteAllLines(Path.Combine(Application.persistentDataPath, fileName), contents);
	}

	//--------------------------------------------------
	// Load Methods
	//--------------------------------------------------
	/// <summary>
	/// セーブしたデータを読み込む。
	/// </summary>
	/// <param name="fileName">読み込むデータの名前。</param>
	/// <returns>読み込んだデータ。</returns>
	public static string Load(string fileName = "save.dat")
	{
		return File.ReadAllText(Path.Combine(Application.persistentDataPath, fileName));
	}

	/// <summary>
	/// セーブしたテキストデータを行毎に読み込む。
	/// </summary>
	/// <param name="fileName">読み込むデータの名前。</param>
	/// <returns>読み込んだテキストデータの配列。</returns>
	public static string[] LoadLines(string fileName = "save.dat")
	{
		return File.ReadAllLines(Path.Combine(Application.persistentDataPath, fileName));
	}
}
