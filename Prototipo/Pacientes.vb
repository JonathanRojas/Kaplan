Imports System.Data.OleDb

Public Class Pacientes
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connectString As String = "Provider=Microsoft.Jet.Oledb.4.0; Data Source=C:\Users\jonathan.rojas\Downloads\Ergosana.mdb"
        Dim cn As OleDbConnection = New OleDbConnection(connectString)
        cn.Open()
        Dim selectString As String = "SELECT * FROM PATIENT_TABLE"
        Dim cmd As OleDbCommand = New OleDbCommand(selectString, cn)
        Dim reader As OleDbDataReader = cmd.ExecuteReader()
        Dim dt As New DataTable()
        dt.Load(reader)
        dg_pacientes.DataSource = dt
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim sqlconn As New OleDb.OleDbConnection
            Dim sqlquery As New OleDb.OleDbCommand
            Dim connString As String
            connString = "Provider=Microsoft.Jet.Oledb.4.0; Data Source=C:\Users\jonathan.rojas\Downloads\Ergosana.mdb"
            sqlconn.ConnectionString = connString
            sqlquery.Connection = sqlconn
            sqlconn.Open()
            sqlquery.CommandText = "INSERT INTO PATIENT_TABLE (Internal_ID, External_ID, Title, Name, First_Name)" +
            "VALUES(@Internal_ID, @External_ID, @Title, @Name, @First_Name)"

            sqlquery.Parameters.AddWithValue("@Internal_ID", "1000")
            sqlquery.Parameters.AddWithValue("@External_ID", "17804243-2")
            sqlquery.Parameters.AddWithValue("@Title", "Mr")
            sqlquery.Parameters.AddWithValue("@Name", "Jonathan")
            sqlquery.Parameters.AddWithValue("@First_Name", "Rojas")
            sqlquery.Parameters.AddWithValue("@Birth_Name", "")
            'sqlquery.Parameters.AddWithValue("@Sex", "0")
            'sqlquery.Parameters.AddWithValue("@Date_of_Birth", "33233")
            'sqlquery.Parameters.AddWithValue("@Age", "28")
            'sqlquery.Parameters.AddWithValue("@Place_of_Birth", "")
            'sqlquery.Parameters.AddWithValue("@Street", "Viña del Mar")
            'sqlquery.Parameters.AddWithValue("@City", "Viña del Mar")
            'sqlquery.Parameters.AddWithValue("@State", "Viña del Mar")
            'sqlquery.Parameters.AddWithValue("@Post_Code", "")
            'sqlquery.Parameters.AddWithValue("@Telephone", "")
            'sqlquery.Parameters.AddWithValue("@Fax", "")
            'sqlquery.Parameters.AddWithValue("@Email", "")
            'sqlquery.Parameters.AddWithValue("@Weight", "85")
            'sqlquery.Parameters.AddWithValue("@Height", "190")
            'sqlquery.Parameters.AddWithValue("@Ward_Room", "")
            'sqlquery.Parameters.AddWithValue("@Insurance_No", "")
            'sqlquery.Parameters.AddWithValue("@Remarks", "Sin Patologías")
            'sqlquery.Parameters.AddWithValue("@Referral_doctor_id", "0")
            'sqlquery.Parameters.AddWithValue("@Deleted", False)
            'sqlquery.Parameters.AddWithValue("@isKgs", True)
            'sqlquery.Parameters.AddWithValue("@isCms", True)
            'sqlquery.Parameters.AddWithValue("@Group_id", "0")
            'sqlquery.Parameters.AddWithValue("@UsrId", "1")
            sqlquery.ExecuteNonQuery()
            sqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
