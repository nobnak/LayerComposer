using UnityEngine;
using System.Collections;
using UnityEditor;

namespace LayerComposer {
	public class LayerCommonEditor {
		[MenuItem("Assets/Create/LayerComposer/LayerCommon")]
		public static void Create() {
			ScriptableObjectUtil.Create<LayerCommon>();
		}
	}
}