//--------------------------------------------------
// MonoBehaviorSingleton継承元クラス
//--------------------------------------------------
using UnityEngine;

[DisallowMultipleComponent]
public class SingletonMonoBehavior<T> : MonoBehaviour 
	where T : SingletonMonoBehavior<T>, new()
{
	protected static GameObject managerObject;

	protected static T _instance = null;
	public static T Instance
	{
		get
		{
			if(_instance == null)
			{
				// エディタ上で設定されていないか確認
				_instance = FindObjectOfType <T>();

				// なければGameObjectを生成しアタッチする
				if (_instance == null)
				{
					if (managerObject == null)
					{
						managerObject = new GameObject("SingletonObject");
					}

					_instance = managerObject.AddComponent<T>();
				}
			}
			return _instance;
		}
	}
}