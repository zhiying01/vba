Public Class checker
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim user As String
        user = TextBox1.Text
        MsgBox(user & " valid " & Validateuser(user))
        Dim password As String
        password = TextBox2.Text
        MsgBox(password & " valid " & ValidatePassword(password))
    End Sub
    Function Validateuser(ByVal User As String,
    Optional ByVal minLength As Integer = 10,
    Optional ByVal numUpper As Integer = 0,
    Optional ByVal numLower As Integer = 0,
    Optional ByVal numSpecial As Integer = 1) As Boolean


        Dim upper As New System.Text.RegularExpressions.Regex("[A-Z]")
        Dim lower As New System.Text.RegularExpressions.Regex("[a-z]")
        ' Special is "none of the above".
        Dim special As New System.Text.RegularExpressions.Regex("@")

        ' Check the length.
        If Len(User) < minLength Then Return False
        ' Check for minimum number of occurrences.
        If upper.Matches(User).Count < numUpper Then Return False
        If lower.Matches(User).Count < numLower Then Return False
        If special.Matches(User).Count < numSpecial Then Return False

        Return True
    End Function
    Function ValidatePassword(ByVal pwd As String,
    Optional ByVal minLength As Integer = 8,
    Optional ByVal numUpper As Integer = 0,
    Optional ByVal numLower As Integer = 0,
    Optional ByVal numNumbers As Integer = 0,
    Optional ByVal numSpecial As Integer = 0) As Boolean

        ' Replace [A-Z] with \p{Lu}, to allow for Unicode uppercase letters.
        Dim upper As New System.Text.RegularExpressions.Regex("[A-Z]")
        Dim lower As New System.Text.RegularExpressions.Regex("[a-z]")
        Dim number As New System.Text.RegularExpressions.Regex("[0-9]")
        ' Special is "none of the above".
        Dim special As New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]")

        ' Check the length.
        If Len(pwd) < minLength Then Return False
        ' Check for minimum number of occurrences.
        If upper.Matches(pwd).Count < numUpper Then Return False
        If lower.Matches(pwd).Count < numLower Then Return False
        If number.Matches(pwd).Count < numNumbers Then Return False
        If special.Matches(pwd).Count < numSpecial Then Return False

        ' Passed all checks.
        Return True
    End Function
End Class