Imports System.Data.OleDb

Public Class LoginPage
    Dim con As New OleDbConnection
    Public customer As String
    Dim s As Boolean = True

    Public Sub New()
        InitializeComponent()

        'Initialize the OleDbConnection object
        con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SQIT3043[1].accdb")
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= D:\SQIT3043[1].accdb"
        con.Open()
        If ComboBox1.Text = "Customer" Then
            Dim customerlogincmd As OleDbCommand = New OleDbCommand("Select customer_ID,customer_Password From Customer Where [customer_ID]='" & Username.Text & "' and [customer_Password]='" & Password.Text & "'", con)
            Dim customerloginID As OleDbDataReader = customerlogincmd.ExecuteReader
            If (customerloginID.Read() = True) Then
                Me.Hide()
                Menu_Category.Show()
                con.Close()
            Else
                MsgBox("Wrong ID or Password", vbExclamation)
                con.Close()
            End If
        ElseIf ComboBox1.Text = "Staff" Then
            Dim stafflogincmd As OleDbCommand = New OleDbCommand("Select staff_ID,staff_Password From Staff Where [staff_ID]='" & Username.Text & "' and [staff_Password]='" & Password.Text & "'", con)
            Dim staffloginID As OleDbDataReader = stafflogincmd.ExecuteReader
            If (staffloginID.Read() = True) Then
                Me.Hide()
                MsgBox("Login Succeeded!", vbInformation)
                OrderView.Show()
                con.Close()

            Else
                MsgBox("Wrong ID or Password", vbExclamation)
                con.Close()

            End If
        End If
    End Sub

    Private Sub Password_TextChanged(sender As Object, e As EventArgs) Handles Password.TextChanged

    End Sub

    Private Sub Username_TextChanged(sender As Object, e As EventArgs) Handles Username.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class
