<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128609487/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2857)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/CommandShortcutChange/Form1.cs) (VB: [Form1.vb](./VB/CommandShortcutChange/Form1.vb))
<!-- default file list end -->
# How to change the shortcut key assigned to a command


<p>Starting with v2010 vol.2.5, the XtraRichEdit Suite enables you to use the <strong>AssignShortcutKeyToCommand</strong> and the <strong>RemoveShortcutKey </strong>methods to change shortcut keys for commands. Prior to implementing these methods it was necessary to create the <strong>RichEditKeyboardHandlerService</strong> descendant to access the <strong>NormalKeyboardHandler</strong> and use its <strong>RegisterKeyHandler </strong>and <strong>UnregisterKeyHandler </strong>methods.<br />
This example contains different projects for different versions illustrating the proper technique.<br />
Note that if default command bar or Ribbon UI is created for the RichEditControl, the <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraBarsBarManagertopic"><u>BarManager</u></a> component located on the form captures shortcut keys assigned to bar items. You should handle the BarManager's <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraBarsBarManager_ShortcutItemClicktopic"><u>ShortcutItemClick</u></a> event and (or) modify the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraBarsBarItemLink_ItemShortcuttopic"><u>ItemShortcut</u></a> property of the corresponding BarItemLink objects to control how shortcuts are processed. See the example code for an illustration of this.</p>

<br/>


