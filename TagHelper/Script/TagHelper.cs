using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// タグ操作補助クラス
/// </summary>
public class TagHelper
{
	/// <summary>
	/// 実行時にのみ有効なタグを追加する。
	/// </summary>
	/// <param name="setTagName">設定したいタグ名。</param>
	public static void AddTag(string setTagName)
	{
		// タグマネージャーアセットを取得
		var tagManager = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");

		if ((tagManager != null) && (tagManager.Length > 0))
		{
			// タグプロパティを取得
			var serializedObject = new SerializedObject(tagManager[0]);
			var tagsProperty = serializedObject.FindProperty("tags");

			// タグが既に登録されていないか確認
			for (int i = 0; i < tagsProperty.arraySize; ++i)
			{
				if (tagsProperty.GetArrayElementAtIndex(i).stringValue == setTagName) return;
			}

			// タグ登録
			var index = tagsProperty.arraySize;
			tagsProperty.InsertArrayElementAtIndex(index);
			tagsProperty.GetArrayElementAtIndex(index).stringValue = setTagName;

			// 更新を保存
			serializedObject.ApplyModifiedProperties();
			serializedObject.Update();
		}
	}
}
