
Imports System
Imports System.Runtime.InteropServices
Imports SharpDX
Imports SharpDX.Direct3D9
Imports SharpDX.Windows
Imports Color = SharpDX.Color

Namespace MiniTri

  <StructLayout(LayoutKind.Sequential)>
  Structure Vertex

    Public Position As Vector4

    Public Color As SharpDX.ColorBGRA
  End Structure

  Module Program

    <STAThread>
    Public Sub DoSomething()
      Dim form = New RenderForm("SlimDX2 - MiniTri Direct3D9 Sample")
      Dim device = New Device(New Direct3D(), 0, DeviceType.Hardware, form.Handle, CreateFlags.HardwareVertexProcessing, New PresentParameters(form.ClientSize.Width, form.ClientSize.Height))
      Dim vertices = New VertexBuffer(device, 3 * 20, Usage.[WriteOnly], VertexFormat.None, Pool.Managed)
      vertices.Lock(0, 0, LockFlags.None).WriteRange({New Vertex() With {.Color = Color.Red, .Position = New Vector4(400.0F, 100.0F, 0.5F, 1.0F)}, New Vertex() With {.Color = Color.Blue, .Position = New Vector4(650.0F, 500.0F, 0.5F, 1.0F)}, New Vertex() With {.Color = Color.Green, .Position = New Vector4(150.0F, 500.0F, 0.5F, 1.0F)}})
      vertices.Unlock()
      Dim vertexElems = {New VertexElement(0, 0, DeclarationType.Float4, DeclarationMethod.[Default], DeclarationUsage.PositionTransformed, 0), New VertexElement(0, 16, DeclarationType.Color, DeclarationMethod.[Default], DeclarationUsage.Color, 0), VertexElement.VertexDeclarationEnd}
      Dim vertexDecl = New VertexDeclaration(device, vertexElems)
      RenderLoop.Run(form, Function()
                             device.Clear(ClearFlags.Target Or ClearFlags.ZBuffer, Color.Black, 1.0F, 0)
                             device.BeginScene()
                             device.SetStreamSource(0, vertices, 0, 20)
                             device.VertexDeclaration = vertexDecl
                             device.DrawPrimitives(PrimitiveType.TriangleList, 0, 1)
                             device.EndScene()
                             device.Present()
                           End Function)
    End Sub


    Public Function CreateControl() As RenderControl
      Dim control = New RenderControl()
      Dim device = New Device(New Direct3D(), 0, DeviceType.Hardware, control.Handle, CreateFlags.HardwareVertexProcessing, New PresentParameters(control.ClientSize.Width, control.ClientSize.Height))
      Dim vertices = New VertexBuffer(device, 3 * 20, Usage.[WriteOnly], VertexFormat.None, Pool.Managed)
      vertices.Lock(0, 0, LockFlags.None).WriteRange({New Vertex() With {.Color = Color.Red, .Position = New Vector4(400.0F, 100.0F, 0.5F, 1.0F)}, New Vertex() With {.Color = Color.Blue, .Position = New Vector4(650.0F, 500.0F, 0.5F, 1.0F)}, New Vertex() With {.Color = Color.Green, .Position = New Vector4(150.0F, 500.0F, 0.5F, 1.0F)}})
      vertices.Unlock()
      Dim vertexElems = {New VertexElement(0, 0, DeclarationType.Float4, DeclarationMethod.[Default], DeclarationUsage.PositionTransformed, 0), New VertexElement(0, 16, DeclarationType.Color, DeclarationMethod.[Default], DeclarationUsage.Color, 0), VertexElement.VertexDeclarationEnd}
      Dim vertexDecl = New VertexDeclaration(device, vertexElems)

      'RenderLoop.Run(control, Function()
      '                          device.Clear(ClearFlags.Target Or ClearFlags.ZBuffer, Color.Black, 1.0F, 0)
      '                          device.BeginScene()
      '                          device.SetStreamSource(0, vertices, 0, 20)
      '                          device.VertexDeclaration = vertexDecl
      '                          device.DrawPrimitives(PrimitiveType.TriangleList, 0, 1)
      '                          device.EndScene()
      '                          device.Present()
      '                        End Function)
      Return control
    End Function
  End Module
End Namespace
