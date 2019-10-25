Imports Test_Program.KoneksiDB

'Impor database helper OLEDB untuk Acesss
Imports System.Data.OleDb

Public Class FormBarang

    'Tampil Data
    Private Sub TampilData()

        Dim DataTable As DataTable
        Dim DataAdapter As OleDbDataAdapter
        Dim QuerySelect As String
        Dim IndexData As Integer

        QuerySelect = "SELECT * FROM tb_barang"
        DataAdapter = New OleDbDataAdapter(QuerySelect, KoneksiDB.conn)
        DataTable = New DataTable
        IndexData = DataAdapter.Fill(DataTable)
        Dim i As Integer = 0

        If IndexData > 0 Then
            dgvTabelBarang.DataSource = DataTable
            dgvTabelBarang.AllowUserToAddRows = False
            dgvTabelBarang.AutoSizeColumnsMode = _
                DataGridViewAutoSizeColumnMode.Fill
            'row number
            For Each row In dgvTabelBarang.Rows
                dgvTabelBarang.Rows(i).HeaderCell.Value = (1 + i).ToString
                i += 1
            Next

            dgvTabelBarang.Columns(0).Visible = False
            dgvTabelBarang.Columns(1).HeaderText = "NAMA BARANG"
            dgvTabelBarang.Columns(2).HeaderText = "MEREK"
            dgvTabelBarang.Columns(3).HeaderText = "JUMLAH"
            dgvTabelBarang.Columns(4).HeaderText = "TANGGAL MASUK"
            dgvTabelBarang.Columns(5).HeaderText = "KONDISI"
        Else
            dgvTabelBarang.DataSource = Nothing
        End If

        bEdit.Enabled = False
        bHapus.Enabled = False
        tbIDBarang.Enabled = False
        KoneksiDB.PutuskanDB()
    End Sub

    'Tampil Jam
    Private Sub TampilJam()
        tJam.Enabled = True
    End Sub

    'Tampil Nama Mhs yang sedang Masuk
    Private Sub TampilNamaMhs()
        lNamaMhs.Text = "Halo " & FormLogin.NamaMhs
    End Sub

    'Tambah Item Kondisi
    Private Sub ItemsKondisi()
        cbKondisi.Items.Add("Baik")
        cbKondisi.Items.Add("Rusak")
        cbKondisi.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    'Bersihkan Form
    Private Sub BersihkanForm()
        tbIDBarang.Clear()
        tbNamaBarang.Clear()
        tbJumlah.Clear()
        tbMerek.Clear()
        tbIDBarang.Enabled = False
        cbKondisi.SelectedIndex = -1
    End Sub

    'Form Load
    Private Sub FormBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TampilData()
        ItemsKondisi()
        TampilJam()
        TampilNamaMhs()
    End Sub

    'Fungsi Simpan
    Private Sub bSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSimpan.Click

        KoneksiDB.HubungkanDB()
        Dim QueryInsert As New OleDbCommand
        Dim strID As String
        strID = System.Guid.NewGuid.ToString()

        Try
            QueryInsert.CommandType = CommandType.Text
            QueryInsert.CommandText = "INSERT INTO tb_barang VALUES ('" & _
                strID & "','" & _
                tbNamaBarang.Text & "', '" & _
                tbMerek.Text & "','" & _
                tbJumlah.Text & "', '" & _
                dtpTanggalMasuk.Text & "', '" & _
                cbKondisi.Text & "')"
            QueryInsert.Connection = KoneksiDB.conn
            QueryInsert.ExecuteNonQuery()
            MsgBox("Barang berhasil disimpan", MsgBoxStyle.Information, "Status")
        Catch ex As Exception
            MsgBox("Data gagal disimpan" + ex.Message, MsgBoxStyle.Critical)
        End Try
        KoneksiDB.PutuskanDB()
        TampilData()
        BersihkanForm()
    End Sub

    'Tampilkan data table pada form
    Private Sub dgvTabelBarang_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTabelBarang.CellClick
        Dim i As Integer
        dgvTabelBarang.ReadOnly = True
        dgvTabelBarang.AllowUserToAddRows = False
        i = Me.dgvTabelBarang.CurrentRow.Index
        With dgvTabelBarang.Rows.Item(i)
            Me.tbIDBarang.Text = .Cells(0).Value
            Me.tbNamaBarang.Text = .Cells(1).Value
            Me.tbMerek.Text = .Cells(2).Value
            Me.tbJumlah.Text = .Cells(3).Value
            Me.dtpTanggalMasuk.Text = .Cells(4).Value
            Me.cbKondisi.Text = .Cells(5).Value
        End With
        tbIDBarang.Enabled = False
        bSimpan.Enabled = False
        bEdit.Enabled = True
        bHapus.Enabled = True
        bBersih.Enabled = True
    End Sub

    'Fungsi Edit
    Private Sub bEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bEdit.Click
        Dim hasil As MsgBoxResult = MessageBox.Show("Apakah data ingin di-edit?", _
                                                    "Pesan", MessageBoxButtons.OKCancel, _
                                                    MessageBoxIcon.Warning)
        If hasil = vbOK Then
            KoneksiDB.HubungkanDB()
            Dim QueryUpdate As New OleDbCommand

            Try
                QueryUpdate.CommandType = CommandType.Text
                QueryUpdate.CommandText = "UPDATE tb_barang SET nama_barang = '" & _
                    tbNamaBarang.Text & "' , merek_barang = '" & _
                    tbMerek.Text & "' , jumlah_barang = '" & _
                    tbJumlah.Text & "' , tanggal_masuk_barang = '" & _
                    dtpTanggalMasuk.Text & "' , kondisi_barang = '" & _
                    cbKondisi.Text & "' WHERE id_barang = '" & tbIDBarang.Text & "'"
                QueryUpdate.Connection = KoneksiDB.conn
                QueryUpdate.ExecuteNonQuery()
                MsgBox("Data Barang berhasil Di-edit", MsgBoxStyle.Information, "Status")
            Catch ex As Exception
                MsgBox("Data Barang gagal Di-edit" + ex.Message, MsgBoxStyle.Critical)
            End Try
            KoneksiDB.PutuskanDB()
            BersihkanForm()
            TampilData()
        End If
    End Sub

    'Fungsi Hapus
    Private Sub bHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bHapus.Click

        Dim hasil As MsgBoxResult = MessageBox.Show("Apakah data ingin dihapus?", _
                                                    "Pesan", MessageBoxButtons.OKCancel, _
                                                    MessageBoxIcon.Warning)
        If hasil = vbOK Then
            KoneksiDB.HubungkanDB()
            Dim QueryDelete As New OleDbCommand
            Try
                QueryDelete.CommandType = CommandType.Text
                QueryDelete.CommandText = "DELETE FROM tb_barang WHERE id_barang = '" & tbIDBarang.Text & "'"
                QueryDelete.Connection = KoneksiDB.conn
                QueryDelete.ExecuteNonQuery()
                MsgBox("Data Barang berhasil Dihapus", MsgBoxStyle.Information, "Status")
            Catch ex As Exception
                MsgBox("Data Barang gagal Dihapus" + ex.Message, MsgBoxStyle.Critical)
            End Try
            KoneksiDB.PutuskanDB()
            BersihkanForm()
            TampilData()
        End If

    End Sub

    'Fungsi Bersih
    Private Sub bBersih_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBersih.Click
        BersihkanForm()
        bSimpan.Enabled = True
        tbIDBarang.Enabled = False
    End Sub

    'Fungsi Pencarian
    Private Sub tbKataKunci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbKataKunci.TextChanged

        Dim DataTableHasil As DataTable
        Dim DataAdapterHasil As OleDbDataAdapter
        Dim QuerySelectHasil As String
        Dim IndexDataHasil As Integer

        QuerySelectHasil = "SELECT * FROM tb_barang WHERE ( kondisi_barang LIKE '%" & tbKataKunci.Text.ToLower & "%' OR nama_barang LIKE '%" & tbKataKunci.Text.ToLower & "%' OR LOWER(merek_barang) LIKE '%" & tbKataKunci.Text.ToLower & "%')"
        DataAdapterHasil = New OleDbDataAdapter(QuerySelectHasil, KoneksiDB.conn)
        DataTableHasil = New DataTable
        IndexDataHasil = DataAdapterHasil.Fill(DataTableHasil)
        Dim i As Integer = 0

        If IndexDataHasil > 0 Then
            dgvTabelBarang.DataSource = DataTableHasil
            dgvTabelBarang.AutoSizeColumnsMode = _
                DataGridViewAutoSizeColumnMode.Fill
            For Each row In dgvTabelBarang.Rows
                dgvTabelBarang.Rows(i).HeaderCell.Value = (1 + i).ToString
                i += 1
            Next
            dgvTabelBarang.Columns(0).Visible = False
            dgvTabelBarang.Columns(1).HeaderText = "NAMA BARANG"
            dgvTabelBarang.Columns(2).HeaderText = "MEREK"
            dgvTabelBarang.Columns(3).HeaderText = "JUMLAH"
            dgvTabelBarang.Columns(4).HeaderText = "TANGGAL MASUK"
            dgvTabelBarang.Columns(5).HeaderText = "KONDISI"
        Else
            dgvTabelBarang.DataSource = Nothing
            MsgBox("Hasil Pencarian Kosong")
        End If
    End Sub

    'set jam agar update
    Private Sub tJam_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tJam.Tick
        lJam.Text = Format(Now, "yyyy-MM-dd hh:mm:ss")
    End Sub

    Private Sub tsmKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmKeluar.Click
        Me.Hide()
        FormLogin.Show()
        FormLogin.bersihForm()
    End Sub

End Class
