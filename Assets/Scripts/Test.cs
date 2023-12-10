using DeerJson;
using UnityEngine;

namespace Plugins.Scripts
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("---Vector2---");
            Debug.Log(new Vector2(20, 30).ToJson());
            Debug.Log(new Vector2(20, 30).ToJson().ParseJson<Vector2>());
            Debug.Log("---Vector3---");
            Debug.Log(new Vector3(20, 30, 40).ToJson());
            Debug.Log(new Vector3(20, 30, 40).ToJson().ParseJson<Vector3>());
            Debug.Log("---Vector4---");
            Debug.Log(new Vector4(20, 30, 40, 50).ToJson());
            Debug.Log(new Vector4(20, 30, 40, 50).ToJson().ParseJson<Vector4>());
            Debug.Log("---Color---");
            var color = new Color(0.3f, 0.4f, 0.5f, 0.6f);
            Debug.Log(color.ToJson());
            Debug.Log(color.ToJson().ParseJson<Color>());
            Debug.Log("---Color32---");
            Debug.Log(new Color32(20, 30, 40, 50).ToJson());
            Debug.Log(new Color32(20, 30, 40, 50).ToJson().ParseJson<Color32>());
            Debug.Log("---Quaternion---");
            Debug.Log(new Quaternion(20, 30, 40, 50).ToJson());
            Debug.Log(new Quaternion(20, 30, 40, 50).ToJson().ParseJson<Quaternion>());
            Debug.Log("---Rect---");
            Debug.Log(new Rect(20, 30, 40, 50).ToJson());
            Debug.Log(new Rect(20, 30, 40, 50).ToJson().ParseJson<Rect>());
            Debug.Log("---Bounds---");
            var bounds = new Bounds(new Vector3(1, 2, 3), new Vector3(4, 5, 6));
            Debug.Log(bounds.ToJson());
            Debug.Log(bounds.ToJson().ParseJson<Bounds>());
            Debug.Log("---KeyFrame---");
            var keyFrame = new Keyframe(1, 2, 3, 4, 0.5f, 0.6f);
            Debug.Log(keyFrame.ToJson());
        }
    }
}