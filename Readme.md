# How to change the shortcut key assigned to a command


<p>Starting with v2010 vol.2.5, the XtraRichEdit Suite enables you to use the <strong>AssignShortcutKeyToCommand</strong> and the <strong>RemoveShortcutKey </strong>methods to change shortcut keys for commands. Prior to implementing these methods it was necessary to create the <strong>RichEditKeyboardHandlerService</strong> descendant to access the <strong>NormalKeyboardHandler</strong> and use its <strong>RegisterKeyHandler </strong>and <strong>UnregisterKeyHandler </strong>methods.<br />
This example contains different projects for different versions illustrating the proper technique.<br />
Note that if default command bar or Ribbon UI is created for the RichEditControl, the <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraBarsBarManagertopic"><u>BarManager</u></a> component located on the form captures shortcut keys assigned to bar items. You should handle the BarManager's <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraBarsBarManager_ShortcutItemClicktopic"><u>ShortcutItemClick</u></a> event and (or) modify the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraBarsBarItemLink_ItemShortcuttopic"><u>ItemShortcut</u></a> property of the corresponding BarItemLink objects to control how shortcuts are processed. See the example code for an illustration of this.</p>

<br/>


