using UnityEngine;
using System.Collections;

namespace LayerComposer {
	public class LayerCommon : ScriptableObject {
		public enum BlendModeEnum { AlphaBlend = 0, Additive, AdditiveAlpha }
		
		public Material[] BlendMaterials;
	}
}