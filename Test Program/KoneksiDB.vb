Imports System.Data.OleDb

Module KoneksiDB
    'Field untuk OleDbConnetion
    'db_lab.accdb adalah nama file database
    'Application.StartupPath mencari direktori dari file accdb
    'Pastikan letakkan file accdb pada [nama_proyek]\bin\Debug\[disini]
    Public conn As New OleDbConnection("Provider=Microsoft.Ace.oledb.12.0;data source=" & Application.StartupPath & "\db_lab.accdb")

    'method untuk menghubungkan aplikasi dengan database
    Public Sub HubungkanDB()

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            'saat file databse gak ada tampilkan pesan ini
        Catch myerror As Exception
            MsgBox("Koneksi Error, Pastikan server database aktif")
            End
        End Try
    End Sub

    'method untuk memutuskan koneksi aplikasi dengan database
    Public Sub PutuskanDB()
        Try
            conn.Close()
            'error di handle oleh System.Data.OleDb.OleDbException
        Catch myerror As System.Data.OleDb.OleDbException

        End Try
    End Sub
End Module
