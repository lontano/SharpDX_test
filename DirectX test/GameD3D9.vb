Imports System
Imports System.Runtime.InteropServices
Imports SharpDX
Imports SharpDX.Direct3D9
Imports SharpDX.Windows
Imports Color = SharpDX.Color


<StructLayout(LayoutKind.Sequential)>
Structure Vertex

  Public Position As Vector4

  Public Color As SharpDX.ColorBGRA
End Structure


Public Class GameD3D9
  Implements IDisposable

  Public Property renderControl As RenderControl
  Public Property device As Device
  Public vertices As VertexBuffer
  Public vertexElems() As VertexElement
  Public vertexDecl As VertexDeclaration


  Public Sub New()
    renderControl = New RenderControl()
    device = New Device(New Direct3D(), 0, DeviceType.Hardware, renderControl.Handle, CreateFlags.HardwareVertexProcessing, New PresentParameters(renderControl.ClientSize.Width, renderControl.ClientSize.Height))
    vertices = New VertexBuffer(device, 3 * 20, Usage.[WriteOnly], VertexFormat.None, Pool.Managed)
    vertices.Lock(0, 0, LockFlags.None).WriteRange(
      {New Vertex() With {.Color = Color.Red, .Position = New Vector4(0.5F, 1.0F, 0.5F, 1.0F)},
      New Vertex() With {.Color = Color.Blue, .Position = New Vector4(0.1F, 0.6F, 0.5F, 1.0F)},
      New Vertex() With {.Color = Color.Green, .Position = New Vector4(0.15F, 0.5F, 0.5F, 1.0F)}})
    vertices.Unlock()
    vertexElems = {New VertexElement(0, 0, DeclarationType.Float4, DeclarationMethod.[Default], DeclarationUsage.PositionTransformed, 0), New VertexElement(0, 16, DeclarationType.Color, DeclarationMethod.[Default], DeclarationUsage.Color, 0), VertexElement.VertexDeclarationEnd}
    vertexDecl = New VertexDeclaration(device, vertexElems)

  End Sub

  Public Sub Run()

    RenderLoop.Run(renderControl, Function()
                                    device.Clear(ClearFlags.Target Or ClearFlags.ZBuffer, Color.Black, 1.0F, 0)
                                    device.BeginScene()
                                    device.SetStreamSource(0, vertices, 0, 20)
                                    device.VertexDeclaration = vertexDecl
                                    device.DrawPrimitives(PrimitiveType.TriangleList, 0, 1)
                                    device.EndScene()
                                    device.Present()
                                  End Function)

  End Sub

  Public Sub Draw()
    device.Clear(ClearFlags.Target Or ClearFlags.ZBuffer, Color.Green, 1.0F, 0)
    device.BeginScene()
    device.SetStreamSource(0, vertices, 0, 20)
    device.VertexDeclaration = vertexDecl
    device.DrawPrimitives(PrimitiveType.TriangleList, 0, 1)
    device.EndScene()
    device.Present()
  End Sub

#Region "IDisposable Support"
  Private disposedValue As Boolean ' To detect redundant calls

  ' IDisposable
  Protected Overridable Sub Dispose(disposing As Boolean)
    If Not disposedValue Then
      If disposing Then
        'dispose managed state (managed objects).
      End If

      ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
      ' TODO: set large fields to null.
    End If
    disposedValue = True
  End Sub

  ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
  'Protected Overrides Sub Finalize()
  '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
  '    Dispose(False)
  '    MyBase.Finalize()
  'End Sub

  ' This code added by Visual Basic to correctly implement the disposable pattern.
  Public Sub Dispose() Implements IDisposable.Dispose
    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    Dispose(True)
    ' TODO: uncomment the following line if Finalize() is overridden above.
    ' GC.SuppressFinalize(Me)
  End Sub
#End Region
End Class
