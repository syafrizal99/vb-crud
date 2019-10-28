Imports Test_Program.KoneksiDB

'Impor database helper OLEDB untuk Acesss
Imports System.Data.OleDb

Public Class FormDaftar

    'Hanya angka input
    Private Sub HanyaAngka(ByVal e)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub tbNimBaru_KeyPress(ByVal sender As Object, ByVal e As  _
                               System.Windows.Forms.KeyPressEventArgs) Handles tbNimBaru.KeyPress
        HanyaAngka(e)
    End Sub

    Private Sub bDaftar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bDaftar.Click

        KoneksiDB.HubungkanDB()
        Dim QueryInsert As New OleDbCommand

        Dim strNimBaru As String = tbNimBaru.Text
        Dim strNamaBaru As String = tbNamaBaru.Text
        Dim strKataSandiBaru As String = tbKatSandiBaru.Text
        Dim strKonfKataSandiBaru As String = tbKonfKataSandi.Text

        If strNimBaru = "" OrElse strNamaBaru = "" OrElse strKataSandiBaru = "" _
            OrElse strKonfKataSandiBaru = "" Then
            MsgBox("Kolom masih ada kosong ", MsgBoxStyle.Critical)

        ElseIf strKataSandiBaru <> strKonfKataSandiBaru Then
            MsgBox("Kata sandi tidak cocok", MsgBoxStyle.Critical)
        Else
            If cekNim() = False Then
                Try
                    QueryInsert.CommandType = CommandType.Text
                    QueryInsert.CommandText = "INSERT INTO tb_user VALUES ('" & _
                        strNimBaru & "', '" & _
                        strNamaBaru & "', '" & _
                        strKataSandiBaru & "')"
                    QueryInsert.Connection = KoneksiDB.conn
                    QueryInsert.ExecuteNonQuery()
                    MsgBox("Akun baru berhasil dibuat", MsgBoxStyle.Information, "Status")
                    BersihkanForm()
                Catch ex As Exception
                    MsgBox("Akun gagal dibuat " + ex.Message, MsgBoxStyle.Critical)
                End Try
            Else
                MsgBox("NIM sudah terdaftar ", MsgBoxStyle.Exclamation, "Error Daftar")
            End If
        End If



        KoneksiDB.PutuskanDB()
    End Sub

    Private Sub BersihkanForm()
        tbNimBaru.Clear()
        tbNamaBaru.Clear()
        tbKatSandiBaru.Clear()
        tbKonfKataSandi.Clear()
        tbNimBaru.Focus()
    End Sub

    Private Sub bBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBatal.Click
        Me.Close()
    End Sub

    Private Sub FormDaftar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub

    'Cek Nim apakah masih tersedia
    Function cekNim() As Boolean
        'membukan koneksi ke database
        KoneksiDB.HubungkanDB()

        Dim CekAuth As OleDbDataReader
        Dim QuerySelect As New OleDbCommand
        Dim strNimBaru As String = tbNimBaru.Text
        Dim cekNimBool As Boolean

        Try
            'pastikan untuk Close() pada setiap ExecuteReader di jalankan
            'CekAuth.Close() => contoh
            QuerySelect.CommandType = CommandType.Text
            QuerySelect.CommandText = "SELECT * FROM tb_user WHERE nim ='" + strNimBaru _
                + "'"
            QuerySelect.Connection = KoneksiDB.conn
            CekAuth = QuerySelect.ExecuteReader()

            If CekAuth.HasRows = True Then
                cekNimBool = True
            Else
                cekNimBool = False
            End If
            CekAuth.Close()
        Catch ex As Exception
            MsgBox("Error" + ex.Message, MsgBoxStyle.Critical)
        End Try

        Return cekNimBool

    End Function

End Class