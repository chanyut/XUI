using UnityEngine;
using UnityUI = UnityEngine.UI;

using System.Collections;

using XUI.Theme.Style;


namespace XUI.Theme.StyleController {

    [ExecuteInEditMode]
    public class XUITextStyleController : XUIBaseStyleController<UnityUI.Text, XUITextStyle> {
        
        public override void ApplyStyle() {
            UnityUI.Text text = mTargetGraphic;
            text.font = style.font;
            text.fontStyle = style.fontStyle;
            text.fontSize = style.fontSize;
            text.color = style.fontColor;
        }

    }

}