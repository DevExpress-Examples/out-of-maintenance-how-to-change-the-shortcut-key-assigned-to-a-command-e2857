Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.Services.Implementation
Imports DevExpress.XtraRichEdit.Keyboard

Namespace CommandShortcutChange
	Public Class MyKeyboardService
		Inherits RichEditKeyboardHandlerService
		Public Sub New(ByVal control As RichEditControl)
			MyBase.New(control)
		End Sub

		Public ReadOnly Property NormalKeyboardHandler() As NormalKeyboardHandler
			Get
				Return TryCast(Handler, NormalKeyboardHandler)
			End Get
		End Property
	End Class
End Namespace
