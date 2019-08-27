using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bezier
{
	/// <summary>
	/// 制御点４つと制御時間を渡すことでベジェ曲線上の座標を算出する
	/// </summary>
	/// <param name="startPoint">開始座標</param>
	/// <param name="endPoint">終了座標</param>
	/// <param name="controllPoint1">制御点 1</param>
	/// <param name="controllPoint2">制御点 2</param>
	/// <param name="nowTime">現在の時間</param>
	/// <param name="targetTime">移動にかかる最終時間(初期は1)</param>
	/// <returns>算出結果</returns>
	public static Vector3 Point(
		Vector3 startPoint,
		Vector3 endPoint,
		Vector3 controllPoint1,
		Vector3 controllPoint2,
		float nowTime,
		float targetTime = 1f)
	{
		// 制御時間が下限と上限(targetTime)をはみ出ないように一度処理
		nowTime = Mathf.Clamp(nowTime, 0f, targetTime);
		// 時差を算出
		var differenceTime = targetTime - nowTime;

		return Mathf.Pow(differenceTime, 3f) * startPoint
			+ Mathf.Pow(differenceTime, 2f) * nowTime * controllPoint1
			+ differenceTime * Mathf.Pow(nowTime, 2f) * controllPoint2
			+ Mathf.Pow(nowTime, 3f) * endPoint;		
	}

	/// <summary>
	/// ベジェ曲線の長さを取得する。ただし正確な数値ではなく、近似値を返す
	/// </summary>
	/// <param name="startPoint">開始座標</param>
	/// <param name="endPoint">終了座標</param>
	/// <param name="controllPoint1">制御点 1</param>
	/// <param name="controllPoint2">制御点 2</param>
	/// <param name="accuracy">精度値。高いほうが精度が高くなる</param>
	/// <returns>近似的な数値</returns>
	public static float Length(
		Vector3 startPoint,
		Vector3 endPoint,
		Vector3 controllPoint1,
		Vector3 controllPoint2,
		int accuracy = 10)
	{
		float total = 0f;
		var difference = 1f / accuracy;
		Vector3 position1 = startPoint;
		Vector3 position2 = Vector3.zero;

		for (int i = 0; i < accuracy; i++)
		{
			position2 = Point(startPoint, endPoint, controllPoint1, controllPoint2, difference * (i + 1));
			total += Vector3.Distance(position1, position2);
			position1 = position2;
		}

		return total;
	}
}
