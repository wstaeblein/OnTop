
Public Class frmAbout

    Private HelpKeyText As String = "Pressione CTRL + $$$ e a janela na qual estiver trabalhando vai ficar na frente das outras ou sair."

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Me.Close()

    End Sub

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lblHelpKey.Text = HelpKeyText.Replace("$$$", MapKeys(My.Settings.Key))

    End Sub


    Private Function MapKeys(ByVal Key As Integer) As String

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

    Private Sub pibBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pibBT.Click

        Try
            Process.Start("http://www.braintime.com.br")

        Catch ex As Exception

        End Try
    End Sub
End Class