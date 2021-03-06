﻿using UnityEngine;
using System.Collections;

namespace LayerComposer {
	public class LayerComposer : MonoBehaviour {
		public int width;
		public int height;
		public LayerData[] layerData;
		public LayerCommon common;

		Layer[] _layers;

		void Start () {
			if (width <= 0)
				width = Screen.width;
			if (height <= 0)
				height = Screen.height;

			_layers = new Layer[layerData.Length];
			for (var i = 0; i < _layers.Length; i++)
				_layers[i] = layerData[i].Create(this, i);
		}

		[System.Serializable]
		public class LayerData {
			
			public Camera camera;
			public LayerCommon.BlendModeEnum blendMode;

			public Layer Create(LayerComposer composer, int i) {
				var common = composer.common;
				var pos = new Vector3(0f, 0f, i * common.layerSpace);
				var layer = (Layer)Instantiate(common.layerfab, pos, Quaternion.identity);
				layer.width = composer.width;
				layer.height = composer.height;
				layer.srcCamera = camera;
				layer.GetComponent<Renderer>().sharedMaterial = common.BlendMaterials[(int)blendMode];
				layer.transform.SetParent(composer.transform, false);
				return layer;
			}
		}
	}
}