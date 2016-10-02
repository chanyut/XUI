using UnityEngine;
using UnityUI = UnityEngine.UI;

using System.Collections;

using XUI.Theme.Style;


namespace XUI.Theme.StyleController {

    [ExecuteInEditMode]
    public abstract class XUIBaseStyleController<UNITY_GRAPHIC, STYLE> : MonoBehaviour
        where UNITY_GRAPHIC : UnityUI.Graphic 
        where STYLE : XUIBaseStyle  {

        public STYLE style;
        protected UNITY_GRAPHIC mTargetGraphic;

        void Awake() {
            UNITY_GRAPHIC g = GetComponent<UNITY_GRAPHIC>();
            if (g == null) {
                Destroy(this);
                return;
            }
            mTargetGraphic = g;
        }

        void Start() {
            if (style != null) {
                ApplyStyle();
            }
        }

#if UNITY_EDITOR
        void Update() {
            if (style != null) {
                ApplyStyle();
            }
        }
#endif

        public virtual void ApplyStyle() {
            throw new System.NotImplementedException();
        }
    }

}