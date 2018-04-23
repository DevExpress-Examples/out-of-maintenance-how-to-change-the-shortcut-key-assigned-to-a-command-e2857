Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.Commands
Imports DevExpress.XtraRichEdit.Keyboard
Imports DevExpress.Services.Implementation
Imports DevExpress.XtraRichEdit.Services.Implementation
Imports DevExpress.Services

Namespace CommandShortcutChange
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
'			#Region "#assignshortcutkey"
			' Register a new shortcut for the RichEditControl without bars 
			richEditControl1.RemoveShortcutKey(Keys.Control Or Keys.Shift, Keys.D8)
			richEditControl1.AssignShortcutKeyToCommand(Keys.Control, Keys.G, RichEditCommandId.ToggleShowWhitespace)

			' Register a new shortcut for the RichEditControl with bars
			richEditControl2.RemoveShortcutKey(Keys.Control Or Keys.Shift, Keys.D8)
			For Each item As DevExpress.XtraBars.BarItem In barManager1.Items
				If item.GetType() Is GetType(DevExpress.XtraRichEdit.UI.ToggleShowWhitespaceItem) Then
					item.ItemShortcut = New DevExpress.XtraBars.BarShortcut((Keys.Control Or Keys.G))
				End If
			Next item
'			#End Region ' #assignshortcutkey

		End Sub

		Private Sub barManager1_ShortcutItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ShortcutItemClickEventArgs) Handles barManager1.ShortcutItemClick
			e.Cancel = Not(FindForm().ActiveControl Is richEditControl2)
		End Sub
	End Class
End Namespace