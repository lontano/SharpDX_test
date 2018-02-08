
Imports SharpDX
Imports SharpDX.D3DCompiler
Imports SharpDX.Direct3D
Imports SharpDX.DXGI
Imports SharpDX.Windows
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports D3D11 = SharpDX.Direct3D11


Public Class GameD3D11
  Implements IDisposable

  Public Property renderControl As RenderControl
  Private Const Width As Integer = 1280
  Private Const Height As Integer = 720
  Private d3dDevice As D3D11.Device
  Private d3dDeviceContext As D3D11.DeviceContext
  Private swapChain As SwapChain
  Private renderTargetView As D3D11.RenderTargetView
  Private viewport As Viewport
  Private vertexShader As D3D11.VertexShader
  Private pixelShader As D3D11.PixelShader
  Private inputSignature As ShaderSignature
  Private inputLayout As D3D11.InputLayout
  Private inputElements As D3D11.InputElement() = New D3D11.InputElement() {New D3D11.InputElement("POSITION", 0, Format.R32G32B32_Float, 0)}
  Private vertices As Vector3() = New Vector3() {New Vector3(-0.5F, 0.5F, 0F), New Vector3(0.5F, 0.5F, 0F), New Vector3(0F, -0.5F, 0F)}
  Private triangleVertexBuffer As D3D11.Buffer

  Public Sub New()
    renderControl = New RenderControl()
    renderControl.ClientSize = New Size(Width, Height)
    'renderForm.AllowUserResizing = False
    InitializeDeviceResources()
    InitializeShaders()
    InitializeTriangle()
  End Sub

  Public Sub Run()
    RenderLoop.Run(renderControl, AddressOf RenderCallback)
  End Sub

  Private Sub RenderCallback()
    Draw()
  End Sub

  Private Sub InitializeDeviceResources()
    Dim backBufferDesc As ModeDescription = New ModeDescription(Width, Height, New Rational(60, 1), Format.R8G8B8A8_UNorm)
    Dim swapChainDesc As SwapChainDescription = New SwapChainDescription() With {.ModeDescription = backBufferDesc, .SampleDescription = New SampleDescription(1, 0), .Usage = Usage.RenderTargetOutput, .BufferCount = 1, .OutputHandle = renderControl.Handle, .IsWindowed = True}
    D3D11.Device.CreateWithSwapChain(DriverType.Hardware, D3D11.DeviceCreationFlags.None, swapChainDesc, d3dDevice, swapChain)
    d3dDeviceContext = d3dDevice.ImmediateContext
    viewport = New Viewport(0, 0, Width, Height)
    d3dDeviceContext.Rasterizer.SetViewport(viewport)
    Using backBuffer As D3D11.Texture2D = swapChain.GetBackBuffer(Of D3D11.Texture2D)(0)
      renderTargetView = New D3D11.RenderTargetView(d3dDevice, backBuffer)
    End Using
  End Sub

  Private Sub InitializeShaders()
    Using vertexShaderByteCode = ShaderBytecode.CompileFromFile("vertexShader.hlsl", "main", "vs_4_0", ShaderFlags.Debug)
      inputSignature = ShaderSignature.GetInputSignature(vertexShaderByteCode)
      vertexShader = New D3D11.VertexShader(d3dDevice, vertexShaderByteCode)
    End Using

    Using pixelShaderByteCode = ShaderBytecode.CompileFromFile("pixelShader.hlsl", "main", "ps_4_0", ShaderFlags.Debug)
      pixelShader = New D3D11.PixelShader(d3dDevice, pixelShaderByteCode)
    End Using

    d3dDeviceContext.VertexShader.[Set](vertexShader)
    d3dDeviceContext.PixelShader.[Set](pixelShader)
    d3dDeviceContext.InputAssembler.PrimitiveTopology = PrimitiveTopology.TriangleList
    inputLayout = New D3D11.InputLayout(d3dDevice, inputSignature, inputElements)
    d3dDeviceContext.InputAssembler.InputLayout = inputLayout
  End Sub

  Private Sub InitializeTriangle()
    triangleVertexBuffer = D3D11.Buffer.Create(Of Vector3)(d3dDevice, D3D11.BindFlags.VertexBuffer, vertices)
  End Sub

  Public Sub Draw()
    d3dDeviceContext.OutputMerger.SetRenderTargets(renderTargetView)
    d3dDeviceContext.ClearRenderTargetView(renderTargetView, New SharpDX.Color(32, 103, 178))
    d3dDeviceContext.InputAssembler.SetVertexBuffers(0, New D3D11.VertexBufferBinding(triangleVertexBuffer, Utilities.SizeOf(Of Vector3)(), 0))
    d3dDeviceContext.Draw(vertices.Count(), 0)
    swapChain.Present(1, PresentFlags.None)
  End Sub

#Region "IDisposable Support"
  Private disposedValue As Boolean ' To detect redundant calls

  ' IDisposable
  Protected Overridable Sub Dispose(disposing As Boolean)
    If Not disposedValue Then
      If disposing Then
        'dispose managed state (managed objects).
        inputLayout.Dispose()
        inputSignature.Dispose()
        triangleVertexBuffer.Dispose()
        vertexShader.Dispose()
        pixelShader.Dispose()
        renderTargetView.Dispose()
        swapChain.Dispose()
        d3dDevice.Dispose()
        d3dDeviceContext.Dispose()
        renderControl.Dispose()
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
