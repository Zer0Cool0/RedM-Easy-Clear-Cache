Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If String.IsNullOrEmpty(My.Settings.redm) Then
            MessageBox.Show("Uh oh! You have not selected your RedM folder! Please do that now! This folder contains 'RedM.exe' and 'RedM Application Data'", "RedM Quick Clear Cache", MessageBoxButtons.OK)
            If Windows.Forms.DialogResult.OK Then
                If BetterFolderBrowser1.ShowDialog() = DialogResult.OK Then
                    My.Settings.redm = BetterFolderBrowser1.SelectedPath
                End If
            End If
        End If

        CenterToScreen()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim path As String = My.Settings.redm + "\RedM.app\data\server-cache-priv"
        If MessageBox.Show("Are you sure you want to clear your cache & launch RedM?", "RedM Quick Clear Cache", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If path <> "" Then
                Dim fileName As String
                For Each fileName In Directory.GetFiles(path, "cache_*")
                    File.Delete(fileName)
                Next
            End If
        End If

        Process.Start(My.Settings.redm + "\RedM.exe")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim path As String = My.Settings.redm + "\RedM.app\data\server-cache-priv"
        If MessageBox.Show("Are you sure you want to clear your cache? ", "RedM Quick Clear Cache", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If path <> "" Then
                Dim fileName As String
                For Each fileName In Directory.GetFiles(path, "cache_*")
                    File.Delete(fileName)
                Next
            End If
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If BetterFolderBrowser1.ShowDialog() = DialogResult.OK Then
            My.Settings.redm = BetterFolderBrowser1.SelectedPath

        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        ''Handles Button for opening redm directory''
        Process.Start(My.Settings.redm)

    End Sub
End Class
