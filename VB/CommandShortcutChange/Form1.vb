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

			' Register a new shortcut for the RichEditControl without bars 
			Dim handler1 As NormalKeyboardHandler = GetKeyboardHandler(richEditControl1)
			If handler1 IsNot Nothing Then
				RemoveOldShortcut(handler1)
				AssignNewShortcut(handler1)
			End If

			' Register a new shortcut for the RichEditControl with bars
			Dim handler2 As NormalKeyboardHandler = GetKeyboardHandler(richEditControl2)
			If handler2 IsNot Nothing Then
				RemoveOldShortcut(handler2)
			End If

			For Each item As DevExpress.XtraBars.BarItem In barManager1.Items
				If item.GetType() Is GetType(DevExpress.XtraRichEdit.UI.ToggleShowWhitespaceItem) Then
					item.ItemShortcut = New DevExpress.XtraBars.BarShortcut((Keys.Control Or Keys.G))
				End If
			Next item
		End Sub

		#Region "KeyboardHandlers"
		Private Function GetKeyboardHandler(ByVal control As RichEditControl) As NormalKeyboardHandler
			Dim myKeyboardService As New MyKeyboardService(control)
			Return myKeyboardService.NormalKeyboardHandler
		End Function

		Public Sub AssignNewShortcut(ByVal handler As NormalKeyboardHandler)
			AssignNewShortcut(New RichEditKeyHashProvider(RichEditViewType.PrintLayout), handler)
			AssignNewShortcut(New RichEditKeyHashProvider(RichEditViewType.Draft), handler)
			AssignNewShortcut(New RichEditKeyHashProvider(RichEditViewType.Simple), handler)
		End Sub

		Public Sub RemoveOldShortcut(ByVal handler As NormalKeyboardHandler)
			RemoveOldShortcut(New RichEditKeyHashProvider(RichEditViewType.PrintLayout), handler)
			RemoveOldShortcut(New RichEditKeyHashProvider(RichEditViewType.Draft), handler)
			RemoveOldShortcut(New RichEditKeyHashProvider(RichEditViewType.Simple), handler)
		End Sub
		Public Sub AssignNewShortcut(ByVal hashProvider As RichEditKeyHashProvider, ByVal normalHandler As NormalKeyboardHandler)
			normalHandler.RegisterKeyHandler(hashProvider, Keys.G, Keys.Control, RichEditCommandId.ToggleShowWhitespace)
		End Sub

		Public Sub RemoveOldShortcut(ByVal hashProvider As RichEditKeyHashProvider, ByVal normalHandler As NormalKeyboardHandler)
			normalHandler.UnregisterKeyHandler(hashProvider, Keys.D8, Keys.Control Or Keys.Shift)
		End Sub
		#End Region ' KeyboardHandlers

		' Prevent BarManager from capturing shortcut keys when its RichEditControl is not active
		Private Sub barManager1_ShortcutItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ShortcutItemClickEventArgs) Handles barManager1.ShortcutItemClick
			e.Cancel = Not(FindForm().ActiveControl Is richEditControl2)
		End Sub
	End Class
End Namespace