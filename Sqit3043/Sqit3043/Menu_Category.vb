Imports System.Data.OleDb

Public Class Menu_Category

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text <> String.Empty AndAlso Not ComboBox1.Items.Contains(ComboBox1.Text) Then
            ComboBox1.SelectAll()

            MessageBox.Show("Please select an item in the drop-down list",
                            "Invalid Item",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub ComboBox1_Validated(sender As Object, e As EventArgs) Handles ComboBox1.Validated
        ComboBox1.SelectedIndex = ComboBox1.FindStringExact(ComboBox1.Text)
    End Sub
End Class