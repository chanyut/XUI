using UnityEngine;
using UnityUI = UnityEngine.UI;
using UnityEditor;

using System.IO;
using System.Collections;

using XUI.Theme.Style;
using XUI.Theme.StyleController;


namespace XUI.Editor {

    public class XUIStyleEditor : EditorWindow {

        const string kResourceFolderName = "Resources";
        const string kXUIStyleFolder = "XUIStyles";
        const string kXUIStyleDirectoryPath = "Assets/Resources/XUIStyles/";

        [MenuItem("CONTEXT/Text/Attach XUIStyle", false)]
        static void AttachTextStyle() {
            GameObject selectedGO = Selection.activeObject as GameObject;
            if (selectedGO == null) {
                return;
            }

            UnityUI.Text text = selectedGO.GetComponent<UnityUI.Text>();
            if (text == null) {
                EditorUtility.DisplayDialog("Attach failed!", "Cannot attached Text style to Non-Text component", "Ok");
                return;
            }

            XUITextStyleController controller = selectedGO.GetComponent<XUITextStyleController>();
            if (controller != null) {
                EditorUtility.DisplayDialog("Already attached!", "This GameObject has already attached TextStyleController.", "Ok");
                return;
            }

            selectedGO.AddComponent<XUITextStyleController>();
        }

        [MenuItem("CONTEXT/Image/Attach XUIStyle")]
        static void AttachImageStyle() {
            GameObject selectedGO = Selection.activeObject as GameObject;
            if (selectedGO == null) {
                return;
            }

            UnityUI.Image image = selectedGO.GetComponent<UnityUI.Image>();
            if (image == null) {
                EditorUtility.DisplayDialog("Attach failed!", "Cannot attached Text style to Non-Text component", "Ok");
                return;
            }

            XUIImageStyleController controller = selectedGO.GetComponent<XUIImageStyleController>();
            if (controller != null) {
                EditorUtility.DisplayDialog("Already attached!", "This GameObject has already been attach TextStyleController.", "Ok");
                return;
            }

            selectedGO.AddComponent<XUIImageStyleController>();
        }


        [MenuItem("XUIStyle/Create Style/Text")]
        static void CreateTextStyle() {
            XUITextStyle asset = CreateStyleAsset<XUITextStyle>("TextStyle");
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }

        [MenuItem("XUIStyle/Create Style/Image")]
        static void CreateImageStyle() {
            XUIImageStyle asset = CreateStyleAsset<XUIImageStyle>("ImageStyle");
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }

        static STYLE CreateStyleAsset<STYLE>(string assetName) where STYLE : XUIBaseStyle {
            CreateStyleDirectoryIfNotExist();
            string styleAssetPath = Path.Combine(kXUIStyleDirectoryPath, assetName + ".asset");
            styleAssetPath = AssetDatabase.GenerateUniqueAssetPath(styleAssetPath);
            STYLE asset = ScriptableObject.CreateInstance<STYLE>();
            AssetDatabase.CreateAsset(asset, styleAssetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            return asset;
        }

        static void CreateStyleDirectoryIfNotExist() {
            string rootPath = Application.dataPath;

            string resourceDirPath = Path.Combine(rootPath, "Resources");
            if (!Directory.Exists(resourceDirPath)) {
                Directory.CreateDirectory(resourceDirPath);
                AssetDatabase.Refresh();
            }

            string styleDirPath = Path.Combine(resourceDirPath, "XUIStyles");
            if (!Directory.Exists(styleDirPath)) {
                Directory.CreateDirectory(styleDirPath);
                AssetDatabase.Refresh();
            }
        }
    }

}