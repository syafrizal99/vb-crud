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
                 DataGridViewAutoSizeColumnMode.AllCells
            'row number
            For Each row In dgvTabelBarang.Rows
                dgvTabelBarang.Rows(i).HeaderCell.Value = (1 + i).ToString
                i += 1
            Next

            dgvTabelBarang.Columns(0).Visible = False
            dgvTabelBarang.Columns(1).HeaderText = "NAMA"
            dgvTabelBarang.Columns(2).HeaderText = "MEREK"
            dgvTabelBarang.Columns(3).HeaderText = "TANGGAL MASUK"
            dgvTabelBarang.Columns(4).HeaderText = "KONDISI"
            dgvTabelBarang.Columns(5).HeaderText = "FUNGSI"
            dgvTabelBarang.Columns(6).HeaderText = "PEMANFATAN"
            dgvTabelBarang.Columns(7).HeaderText = "JUMLAH"
            dgvTabelBarang.Columns(8).HeaderText = "ASAL"
            dgvTabelBarang.Columns(9).HeaderText = "KETERANGAN"
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
        cbKondisi.Items.Add("Baik Sepenuhnya")
        cbKondisi.Items.Add("Rusak Sebagian")
        cbKondisi.Items.Add("Rusak Tidak Beroperasi")
        cbKondisi.SelectedIndex = 0
        cbKondisi.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    'Tambah Item Pemanfaatan
    Private Sub ItemsPemanfaatan()
        cbPemanfaatan.Items.Add("Penelitian dan Pendidikan")
        cbPemanfaatan.Items.Add("Penelitian")
        cbPemanfaatan.Items.Add("Pendidikan")
        cbPemanfaatan.Items.Add("Pelayanan")
        cbPemanfaatan.SelectedIndex = 0
        cbPemanfaatan.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    'Tambah Item Asal
    Private Sub ItemsAsal()
        cbAsal.Items.Add("Universitas Sumatera Utara")
        cbAsal.Items.Add("Hibah")
        cbAsal.Items.Add("Pribadi")
        cbAsal.SelectedIndex = 0
        cbAsal.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    'Hanya angka input
    Private Sub HanyaAngka(ByVal e)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    'Bersihkan Form
    Private Sub BersihkanForm()
        tbIDBarang.Clear()
        tbNamaBarang.Clear()
        tbMerek.Clear()
        tbJumlah.Clear()
        tbFungsi.Clear()
        tbKeterangan.Clear()
        tbIDBarang.Enabled = False
    End Sub

    'Form Load
    Private Sub FormBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ItemsKondisi()
        ItemsPemanfaatan()
        ItemsAsal()
        TampilData()
        TampilJam()
        TampilNamaMhs()
    End Sub

    'Fungsi Simpan
    Private Sub bSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSimpan.Click

        KoneksiDB.HubungkanDB()
        Dim QueryInsert As New OleDbCommand
        'Dim strID As String
        'strID = System.Guid.NewGuid.ToString()
        Dim strKode As String
        Dim RandId As New Random

        Dim strNama As String = tbNamaBarang.Text
        Dim strMerek As String = tbMerek.Text
        Dim strTanggalMasuk As String = dtpTanggalMasuk.Text
        Dim strKondisi As String = cbKondisi.SelectedItem.ToString
        Dim strFungsi As String = tbFungsi.Text
        Dim strPemanfaatan As String = cbPemanfaatan.SelectedItem.ToString
        Dim intJumlah As Integer = Val(tbJumlah.Text)
        Dim strAsal As String = cbAsal.SelectedItem.ToString
        Dim strKeterangan As String = tbKeterangan.Text

        If strNama = "" OrElse strMerek = "" OrElse _
            strTanggalMasuk = "" OrElse strKondisi = "" OrElse strFungsi = "" OrElse strPemanfaatan = "" OrElse _
            intJumlah < 0 OrElse strAsal = "" OrElse strKeterangan = "" Then
            MsgBox("Form masih ada yang kosong", MsgBoxStyle.Critical)
        Else
            Try
                strKode = strNama.ToString.Substring(0, 4).ToUpper & "-" & _
                    strTanggalMasuk.ToString.Substring(strTanggalMasuk.Length - 5)

                QueryInsert.CommandType = CommandType.Text
                QueryInsert.CommandText = "INSERT INTO tb_barang VALUES ('" & _
                    strKode & "-" & RandId.Next(1000, 9999).ToString & "','" & _
                    strNama & "', '" & _
                    strMerek & "','" & _
                    strTanggalMasuk & "','" & _
                    strKondisi & "','" & _
                    strFungsi & "','" & _
                    strPemanfaatan & "','" & _
                    intJumlah & "','" & _
                    strAsal & "','" & _
                    strKeterangan & "')"
                QueryInsert.Connection = KoneksiDB.conn
                QueryInsert.ExecuteNonQuery()
                MsgBox("Barang berhasil disimpan", MsgBoxStyle.Information, "Status")
                BersihkanForm()
            Catch ex As Exception
                MsgBox("Data gagal disimpan " + ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
        KoneksiDB.PutuskanDB()
        TampilData()
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
            Me.dtpTanggalMasuk.Text = .Cells(3).Value
            Me.cbKondisi.Text = .Cells(4).Value
            Me.tbFungsi.Text = .Cells(5).Value
            Me.cbPemanfaatan.Text = .Cells(6).Value
            Me.tbJumlah.Text = .Cells(7).Value
            Me.cbAsal.Text = .Cells(8).Value
            Me.tbKeterangan.Text = .Cells(9).Value
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

            Dim strID As String = tbIDBarang.Text
            Dim strNama As String = tbNamaBarang.Text
            Dim strMerek As String = tbMerek.Text
            Dim strTanggalMasuk As String = dtpTanggalMasuk.Text
            Dim strKondisi As String = cbKondisi.SelectedItem.ToString
            Dim strFungsi As String = tbFungsi.Text
            Dim strPemanfaatan As String = cbPemanfaatan.SelectedItem.ToString
            Dim intJumlah As Integer = Val(tbJumlah.Text)
            Dim strAsal As String = cbAsal.SelectedItem.ToString
            Dim strKeterangan As String = tbKeterangan.Text

            Try
                QueryUpdate.CommandType = CommandType.Text
                QueryUpdate.CommandText = "UPDATE tb_barang SET nama_barang = '" & _
                    strNama & "' , merek_barang = '" & _
                    strMerek & "' , tanggal_masuk_barang = '" & _
                    strTanggalMasuk & "' , kondisi_barang = '" & _
                    strKondisi & "' , fungsi_barang = '" & _
                    strFungsi & "' , pemanfaatan_barang = '" & _
                    strPemanfaatan & "' , jumlah_barang = '" & _
                    intJumlah & "' , asal_barang = '" & _
                    strAsal & "' , keterangan_barang = '" & _
                    strKeterangan & "' WHERE id_barang = '" & strID & "'"
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

        Try
            'QuerySelectHasil = "SELECT * FROM tb_barang WHERE ( kondisi_barang LIKE '%" & tbKataKunci.Text.ToLower & "%' OR nama_barang LIKE '%" & tbKataKunci.Text.ToLower & "%' OR LOWER(merek_barang) LIKE '%" & tbKataKunci.Text.ToLower & "%')"
            QuerySelectHasil = "SELECT * FROM tb_barang WHERE kondisi_barang LIKE '%" & tbKataKunci.Text.ToLower & "%' OR nama_barang LIKE '%" & tbKataKunci.Text.ToLower & "%' OR LCASE(merek_barang) LIKE '%" & tbKataKunci.Text.ToLower & "%'"
            DataAdapterHasil = New OleDbDataAdapter(QuerySelectHasil, KoneksiDB.conn)
            DataTableHasil = New DataTable
            IndexDataHasil = DataAdapterHasil.Fill(DataTableHasil)
            Dim i As Integer = 0

            If IndexDataHasil > 0 Then
                dgvTabelBarang.DataSource = DataTableHasil
                dgvTabelBarang.AutoSizeColumnsMode = _
                    DataGridViewAutoSizeColumnMode.AllCells
                For Each row In dgvTabelBarang.Rows
                    dgvTabelBarang.Rows(i).HeaderCell.Value = (1 + i).ToString
                    i += 1
                Next
                dgvTabelBarang.Columns(0).Visible = False
                dgvTabelBarang.Columns(1).HeaderText = "NAMA"
                dgvTabelBarang.Columns(2).HeaderText = "MEREK"
                dgvTabelBarang.Columns(3).HeaderText = "TANGGAL MASUK"
                dgvTabelBarang.Columns(4).HeaderText = "KONDISI"
                dgvTabelBarang.Columns(5).HeaderText = "FUNGSI"
                dgvTabelBarang.Columns(6).HeaderText = "PEMANFATAN"
                dgvTabelBarang.Columns(7).HeaderText = "JUMLAH"
                dgvTabelBarang.Columns(8).HeaderText = "ASAL"
                dgvTabelBarang.Columns(9).HeaderText = "KETERANGAN"
            Else
                dgvTabelBarang.DataSource = Nothing
                MsgBox("Hasil Pencarian Kosong")
            End If
        Catch ex As Exception
            MsgBox("Tabel masih kosong!! ", MsgBoxStyle.Exclamation, "Error Pencarian")
        End Try

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

    Private Sub TambahPenggunaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmTambahPengguna.Click
        FormDaftar.Show()
    End Sub

    Private Sub tbJumlah_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbJumlah.KeyPress
        HanyaAngka(e)
    End Sub

End Class
