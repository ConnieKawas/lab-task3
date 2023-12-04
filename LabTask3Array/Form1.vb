'CONNIE KAWAS / 20DDT21F2030
Public Class Form1
    ' One-dimensional array to store app names
    Dim apps(4) As String
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Dim appName As String = InputBox("Enter the name of the app to add:", "Add App")

        ' Check if the array is full
        If apps.Length = apps.Count(Function(a) a IsNot Nothing) Then
            MessageBox.Show("Error: The app list is full. Unable to add a new app.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Add the app to the first available slot
        For i = 0 To apps.Length - 1
            If apps(i) Is Nothing Then
                apps(i) = appName
                MessageBox.Show($"App '{appName}' added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit For
            End If
        Next

    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Dim oldAppName As String = InputBox("Enter the name of the app to update:", "Update App")

        ' Check if the app exists
        If Not apps.Contains(oldAppName) Then
            MessageBox.Show($"Error: App '{oldAppName}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim newAppName As String = InputBox($"Enter the new name for the app '{oldAppName}':", "Update App")

        ' Update the app name
        For i = 0 To apps.Length - 1
            If apps(i) = oldAppName Then
                apps(i) = newAppName
                MessageBox.Show($"App '{oldAppName}' updated to '{newAppName}' successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit For
            End If
        Next

    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        ListboxApps.Items.Clear()

        ' Display all installed apps in the listbox
        For Each app In apps
            If app IsNot Nothing Then
                ListboxApps.Items.Add(app)
            End If
        Next
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Dim appNameToDelete As String = InputBox("Enter the name of the app to delete:", "Delete App")
        ' Check if the app exists
        If Not apps.Contains(appNameToDelete) Then
            MessageBox.Show($"Error: App '{appNameToDelete}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Delete the app
        For i = 0 To apps.Length - 1
            If apps(i) = appNameToDelete Then
                apps(i) = Nothing
                MessageBox.Show($"App '{appNameToDelete}' deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit For
            End If
        Next

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize sample app names
        apps(0) = "App1"
        apps(1) = "App2"
        apps(2) = "App3"
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub
End Class
