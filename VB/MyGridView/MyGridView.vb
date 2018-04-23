﻿Imports System

Namespace CustomGrid
	Public Class MyGridView
		Inherits DevExpress.XtraGrid.Views.Grid.GridView

		Public Sub New()
			Me.New(Nothing)
		End Sub
		Public Sub New(ByVal grid As DevExpress.XtraGrid.GridControl)
			MyBase.New(grid)
		End Sub
		Protected Overrides ReadOnly Property ViewName() As String
			Get
				Return "MyGridView"
			End Get
		End Property
	End Class
End Namespace
