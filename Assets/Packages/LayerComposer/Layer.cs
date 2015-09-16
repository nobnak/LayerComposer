using UnityEngine;
using System.Collections;

namespace LayerComposer {
	public class Layer : MonoBehaviour {
		public const string PROP_MAIN_TEXTURE = "_MainTex";

		public Camera srcCamera;
		public float depth = -1f;
		public int width, height;

		MaterialPropertyBlock _props;
		RenderTexture _capture;

		void Start() {
			if (width <= 0)
				width = Screen.width;
			if (height <= 0)
				height = Screen.height;
			if (depth <= 0f)
				depth = srcCamera.nearClipPlane;

			var viewport = srcCamera.rect;
			var size = srcCamera.ViewportToWorldPoint(new Vector3(viewport.width, viewport.height, depth))
				- srcCamera.ViewportToWorldPoint(new Vector3(0f, 0f, depth));
			size.z = 1f;
			transform.localScale = size;

			_capture = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32);
			_capture.antiAliasing = (QualitySettings.antiAliasing == 0 ? 1 : QualitySettings.antiAliasing);
			_capture.filterMode = FilterMode.Bilinear;
			_capture.wrapMode = TextureWrapMode.Clamp;
			_props = new MaterialPropertyBlock();
			_props.SetTexture(PROP_MAIN_TEXTURE, _capture);
			GetComponent<Renderer>().SetPropertyBlock(_props);
			srcCamera.targetTexture = _capture;
		}
		void OnDestroy() {
			if (_capture != null) {
				if (srcCamera != null)
					srcCamera.targetTexture = null;
				Destroy(_capture);
			}
		}
	}
}