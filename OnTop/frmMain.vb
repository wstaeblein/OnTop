
Imports System.Runtime.InteropServices

Public Class frmMain

    Private objMutex As System.Threading.Mutex
    Private EndFlag As Boolean = False

    Private HookFlag As Boolean = True
    Private Const WH_KEYBOARD_LL As Integer = 13
    Private Const WM_KEYUP As Integer = &H101
    Private Const WM_SYSKEYUP As Integer = &H105
    Private Const WM_KEYDOWN = &H100
    Private Const WM_SYSKEYDOWN = &H104
    Private proc As LowLevelKeyboardProcDelegate = AddressOf HookCallback
    Private hookID As IntPtr

    Private Delegate Function LowLevelKeyboardProcDelegate(ByVal nCode As Integer, ByVal wParam As IntPtr, _
        ByVal lParam As IntPtr) As IntPtr

    <DllImport("user32")> _
    Private Shared Function SetWindowsHookEx(ByVal idHook As Integer, ByVal lpfn As LowLevelKeyboardProcDelegate, _
        ByVal hMod As IntPtr, ByVal dwThreadId As UInteger) As IntPtr
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function UnhookWindowsHookEx(ByVal hhk As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function CallNextHookEx(ByVal hhk As IntPtr, ByVal nCode As Integer, ByVal wParam As IntPtr, _
        ByVal lParam As IntPtr) As IntPtr
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function GetModuleHandle(ByVal lpModuleName As String) As IntPtr
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function FlashWindow(ByVal hwnd As Long, ByVal bInvert As Long) As Long
    End Function

    Private Declare Auto Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (ByVal hwnd As Long, ByVal nIndex As Long) As Long

    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function GetForegroundWindow() As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As IntPtr) As Boolean
    End Function

    Private Const HWND_TOPMOST = -1
    Private Const HWND_NOTOPMOST = -2
    Private Const SWP_NOMOVE = &H2
    Private Const SWP_NOSIZE = &H1
    Private Const SWP_NOACTIVATE = &H10
    Private Const SWP_SHOWWINDOW = &H40
    Private Const GWL_EXSTYLE = -20
    Private Const WS_EX_TOPMOST As Int32 = &H8I
    'Private LastKeyTime As DateTime = DateTime.MinValue
    'Private LastKey As Integer = -1
    Private CTRLFlag As Boolean = False

    Sub New()

        ' Checa se há outra instância da aplicação
        objMutex = New System.Threading.Mutex(False, Application.ProductName & "." & Application.ProductVersion)

        If objMutex.WaitOne(0, False) = False Then
            objMutex.Close()
            objMutex = Nothing
            MsgBox("Há outra instância desta aplicação rodando!")

            End
        Else
            GC.Collect()
            GC.KeepAlive(objMutex)
        End If

        InitializeComponent()
        Text = "OnTop v1.0"


        hookID = SetHook(proc)
    End Sub

    ''' <summary>
    ''' Faz o form iniciar invisível
    ''' </summary>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub SetVisibleCore(ByVal value As Boolean)
        If Not Me.IsHandleCreated Then
            Me.CreateHandle()
            value = False
        End If
        MyBase.SetVisibleCore(value)
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If My.Settings.Key = 0 Then
            My.Settings.Key = 123
            My.Settings.Save()
        End If

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        UnhookWindowsHookEx(hookID)
    End Sub

    Private Function SetHook(ByVal proc As LowLevelKeyboardProcDelegate) As IntPtr
        Using curProcess As Process = Process.GetCurrentProcess()
            Using curModule As ProcessModule = curProcess.MainModule
                Return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0)
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Callback do hook universal de teclado
    ''' </summary>
    ''' <param name="nCode"></param>
    ''' <param name="wParam"></param>
    ''' <param name="lParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function HookCallback(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

        If HookFlag = True Then

            If nCode >= 0 Then

                Dim CTRLKey As Integer = 162
                Dim vkCode As Integer = Marshal.ReadInt32(lParam)
                Dim MyKey As Int32 = My.Settings.Key

                If (wParam.ToInt32 = WM_KEYDOWN OrElse wParam.ToInt32 = WM_SYSKEYDOWN) Then

                    If vkCode = 162 Then
                        CTRLFlag = True
                    End If
                End If



                If (wParam.ToInt32 = WM_KEYUP OrElse wParam.ToInt32 = WM_SYSKEYUP) Then

                    If vkCode = 162 Then
                        CTRLFlag = False
                    End If

                    Debug.Print(vkCode & " = " & MyKey)

                    'If ((vkCode = MyKey AndAlso LastKey = CTRLKey) OrElse (vkCode = CTRLKey And LastKey = MyKey)) AndAlso Now.AddMilliseconds(-100) < LastKeyTime Then
                    If vkCode = MyKey AndAlso CTRLFlag = True Then

                        'LastKeyTime = DateTime.MinValue
                        Dim Handle As IntPtr = GetForegroundWindow()
                        Debug.Print(Handle)

                        If IsTopMost(Handle) = False Then
                            SetWindowPos(Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE)
                        Else
                            SetWindowPos(Handle, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOSIZE Or SWP_NOMOVE)
                        End If

                        If My.Settings.FlashTarget = True Then
                            FlashWindow(Handle, 1)
                        End If

                    End If

                    'LastKey = vkCode
                    'LastKeyTime = Now

                End If

            End If

        End If

        Return CallNextHookEx(hookID, nCode, wParam, lParam)

    End Function

    ''' <summary>
    ''' Determina se a janela passada está com o atributo TopMost setado
    ''' </summary>
    ''' <param name="Handle">Handle da janela</param>
    ''' <returns>True se o atributo estiver setado</returns>
    ''' <remarks></remarks>
    Private Function IsTopMost(ByVal Handle As Int32) As Boolean

        Dim lStyle As Long

        lStyle = GetWindowLong(Handle, GWL_EXSTYLE)
        Return (lStyle And WS_EX_TOPMOST)

    End Function

    Private Sub TerminarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TerminarToolStripMenuItem.Click

        Me.Close()

    End Sub

    Private Sub SobreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SobreToolStripMenuItem.Click

        frmAbout.ShowDialog(Me)

    End Sub

    Private Sub PararToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PararToolStripMenuItem.Click

        HookFlag = False
        Tray.Icon = My.Resources.OnTop_dis
        PararToolStripMenuItem.Enabled = False
        IniciarToolStripMenuItem.Enabled = True

    End Sub

    Private Sub IniciarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IniciarToolStripMenuItem.Click

        HookFlag = True
        Tray.Icon = My.Resources.OnTop
        PararToolStripMenuItem.Enabled = True
        IniciarToolStripMenuItem.Enabled = False

    End Sub

    Private Sub ConfiguraçõesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguraçõesToolStripMenuItem.Click

        frmSettings.ShowDialog(Me)

    End Sub
End Class
