Public Class Form1
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = Replace(DateTimePicker1.Value.Date, "/", "-")
        If TextBox1.Text.Contains("-0") Then
            TextBox1.Text = Replace(TextBox1.Text, "-0", "-")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        testeObj(Label1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox(DataGridView1.Rows.Count - 1)
        For i As Integer = 0 To DataGridView1.Rows.Count - 2
            If (i Mod 2 <> 0) Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            End If
        Next]
    End Sub
End Class
