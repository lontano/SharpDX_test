Imports SharpDX.Windows
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks


Public Class UCGame
  Implements IDisposable


  Private renderForm As RenderForm

  'Private Const Width As Integer = 1280

  'Private Const Height As Integer = 720

  Private Sub Game_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    renderForm = New RenderForm("My first SharpDX game")
    renderForm.ClientSize = New Size(Width, Height)
    renderForm.AllowUserResizing = False
  End Sub

  Public Sub Run()
    RenderLoop.Run(renderForm, AddressOf RenderCallback)
  End Sub

  Public Sub RenderCallback()

  End Sub

  Public Overloads Sub Dispose()
    renderForm.Dispose()
  End Sub
End Class
