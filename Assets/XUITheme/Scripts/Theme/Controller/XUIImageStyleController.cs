using UnityEngine;
using UnityUI = UnityEngine.UI;

using System.Collections;

using XUI.Theme.Style;

namespace XUI.Theme.StyleController {

    public class XUIImageStyleController : XUIBaseStyleController<UnityUI.Image, XUIImageStyle> {

        public override void ApplyStyle() {
            UnityUI.Image image = mTargetGraphic;
            image.color = style.backgroundColor;
        }

    }

}