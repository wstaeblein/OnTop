Imports Microsoft.Win32

Public Class frmSettings

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Me.Close()

    End Sub

    Private Function MapKeys(ByVal Key As String) As Integer

        Select Case Key
            Case "F1" : Return 112
            Case "F2" : Return 113
            Case "F3" : Return 114
            Case "F4" : Return 115
            Case "F5" : Return 116
            Case "F6" : Return 117
            Case "F7" : Return 118
            Case "F8" : Return 119
            Case "F9" : Return 120
            Case "F10" : Return 121
            Case "F11" : Return 122
            Case "F12" : Return 123
            Case "Insert" : Return 45
            Case "PageUp" : Return 33
            Case "ScrollLock" : Return 145

            Case Else : Return 123          ' Default é F12
        End Select
    End Function

    Private Function MapKeysString(ByVal Key As Integer) As String

        Select Case Key
            Case 112 : Return "F1"
            Case 113 : Return "F2"
            Case 114 : Return "F3"
            Case 115 : Return "F4"
            Case 116 : Return "F5"
            Case 117 : Return "F6"
            Case 118 : Return "F7"
            Case 119 : Return "F8"
            Case 120 : Return "F9"
            Case 121 : Return "F10"
            Case 122 : Return "F11"
            Case 123 : Return "F12"
            Case 45 : Return "Insert"
            Case 33 : Return "PageUp"
            Case 145 : Return "ScrollLock"

            Case Else : Return "F12"          ' Default é F12
        End Select
    End Function


    Public Sub RunAtStartUp(ByVal ApplicationName As String, ByVal ApplicationPath As String)

        Dim CU As Microsoft.Win32.RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run")
        With CU
            .OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)

            .SetValue(ApplicationName, ApplicationPath)

        End With
    End Sub

    Public Sub DontRunAtStartUp(ByVal ApplicationName As String)

        Dim CU As Microsoft.Win32.RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run")
        With CU
            .OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)

            .DeleteValue(ApplicationName, False)

        End With
    End Sub



    Private Sub chkStartWithOS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStartWithOS.CheckedChanged

        My.Settings.StartWithOS = chkStartWithOS.Checked
        My.Settings.Save()

        If chkStartWithOS.Checked = True Then
            RunAtStartUp(Application.ProductName, Application.ExecutablePath)
        Else
            DontRunAtStartUp(Application.ProductName)
        End If

    End Sub

    Private Sub chkFlashTarget_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFlashTarget.CheckedChanged

        My.Settings.FlashTarget = chkFlashTarget.Checked
        My.Settings.Save()

    End Sub

    Private Sub cbKey_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbKey.SelectedIndexChanged

        My.Settings.Key = MapKeys(cbKey.Text)
        My.Settings.Save()

    End Sub

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        chkFlashTarget.Checked = My.Settings.FlashTarget
        chkStartWithOS.Checked = My.Settings.StartWithOS

        cbKey.Text = MapKeysString(My.Settings.Key)

    End Sub
End Class