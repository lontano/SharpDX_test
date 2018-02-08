Public Class Form1
  Private WithEvents _game As GameD3D11
  Private WithEvents _game2 As GameD3D9
  Private Sub ButtonGameRun_Click(sender As Object, e As EventArgs) Handles ButtonGameRun.Click

    _game = New GameD3D11()
    Me.PanelContainer.Controls.Add(_game.renderControl)
    _game.renderControl.Dock = DockStyle.Fill
    _game.Draw()

    _game2 = New GameD3D9()
    Me.Panel1.Controls.Add(_game2.renderControl)
    _game2.renderControl.Dock = DockStyle.Fill
    _game2.Draw()
    ' _game2.Run()

  End Sub

  Private Sub TimerReDraw_Tick(sender As Object, e As EventArgs) Handles TimerReDraw.Tick
    If Not _game Is Nothing Then _game.Draw()
    If Not _game2 Is Nothing Then _game2.Draw()
  End Sub

  Private Sub ButtonMinitri_Click(sender As Object, e As EventArgs) Handles ButtonMinitri.Click
    MiniTri.DoSomething()
  End Sub
End Class
