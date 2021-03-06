using UnityEngine.Rendering.Universal;

namespace UnityEditor.Rendering.Universal
{
    [VolumeComponentEditor(typeof(SplitToning))]
    sealed class SplitToningEditor : VolumeComponentEditor
    {
        public override void OnInspectorGUI()
        {
            if (UniversalRenderPipeline.asset?.postProcessingFeatureSet == PostProcessingFeatureSet.PostProcessingV2)
            {
                EditorGUILayout.HelpBox(UniversalRenderPipelineAssetEditor.Styles.postProcessingGlobalWarning, MessageType.Warning);
                return;
            }

            base.OnInspectorGUI();
        }
    }
}
