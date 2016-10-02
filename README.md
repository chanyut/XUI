# XUI
UI Theme/Style system for Unity UI (uGUI)

## Do I really need Style system for Unity UI?
In my previous Game project, there are so many UI pages, most of them are Text!. It's really painful, when the UI design was changed, I have to edit Font size, style or color. There are 20-30 Texts to be edited. Prefab do not help me in this situation. Because each UI page is also linked with prefab. So the linkage between my Text prefab and the Tex, inside each UI page, was broken.

## How to Create and apply Style to UI Component
Right now, XUI supports only two UI components: 
* Text
* Image

1. First, you have to create a Style object. By using Menu XUIStyle > Create Style > Text
2. New style object will be placed in folder Assets/Resources/XUIStyle/
3. Drag XUITextStyleController to Text gameObject. Or click at Gear icon on Text inspector to pop up Context menu, and then select Attach XUIStyle.
4. In XUITextStyleController inspector, assign the style you have created in Step 1 to Style field




