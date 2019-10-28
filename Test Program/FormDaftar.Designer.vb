<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDaftar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbTambahAkun = New System.Windows.Forms.GroupBox()
        Me.lKonfKataSandiBaru = New System.Windows.Forms.Label()
        Me.lKataSandi = New System.Windows.Forms.Label()
        Me.lNim = New System.Windows.Forms.Label()
        Me.tbKonfKataSandi = New System.Windows.Forms.TextBox()
        Me.tbKatSandiBaru = New System.Windows.Forms.TextBox()
        Me.tbNimBaru = New System.Windows.Forms.TextBox()
        Me.bDaftar = New System.Windows.Forms.Button()
        Me.bBatal = New System.Windows.Forms.Button()
        Me.tbNamaBaru = New System.Windows.Forms.TextBox()
        Me.lNamaLengkap = New System.Windows.Forms.Label()
        Me.gbTambahAkun.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTambahAkun
        '
        Me.gbTambahAkun.Controls.Add(Me.lKonfKataSandiBaru)
        Me.gbTambahAkun.Controls.Add(Me.lNamaLengkap)
        Me.gbTambahAkun.Controls.Add(Me.lKataSandi)
        Me.gbTambahAkun.Controls.Add(Me.lNim)
        Me.gbTambahAkun.Controls.Add(Me.tbKonfKataSandi)
        Me.gbTambahAkun.Controls.Add(Me.tbNamaBaru)
        Me.gbTambahAkun.Controls.Add(Me.tbKatSandiBaru)
        Me.gbTambahAkun.Controls.Add(Me.tbNimBaru)
        Me.gbTambahAkun.Controls.Add(Me.bDaftar)
        Me.gbTambahAkun.Controls.Add(Me.bBatal)
        Me.gbTambahAkun.Location = New System.Drawing.Point(12, 25)
        Me.gbTambahAkun.Name = "gbTambahAkun"
        Me.gbTambahAkun.Size = New System.Drawing.Size(194, 257)
        Me.gbTambahAkun.TabIndex = 0
        Me.gbTambahAkun.TabStop = False
        Me.gbTambahAkun.Text = "Tambah Akun"
        '
        'lKonfKataSandiBaru
        '
        Me.lKonfKataSandiBaru.AutoSize = True
        Me.lKonfKataSandiBaru.Location = New System.Drawing.Point(15, 162)
        Me.lKonfKataSandiBaru.Name = "lKonfKataSandiBaru"
        Me.lKonfKataSandiBaru.Size = New System.Drawing.Size(110, 13)
        Me.lKonfKataSandiBaru.TabIndex = 1
        Me.lKonfKataSandiBaru.Text = "Konfirmasi Kata Sandi"
        '
        'lKataSandi
        '
        Me.lKataSandi.AutoSize = True
        Me.lKataSandi.Location = New System.Drawing.Point(15, 115)
        Me.lKataSandi.Name = "lKataSandi"
        Me.lKataSandi.Size = New System.Drawing.Size(59, 13)
        Me.lKataSandi.TabIndex = 1
        Me.lKataSandi.Text = "Kata Sandi"
        '
        'lNim
        '
        Me.lNim.AutoSize = True
        Me.lNim.Location = New System.Drawing.Point(15, 26)
        Me.lNim.Name = "lNim"
        Me.lNim.Size = New System.Drawing.Size(27, 13)
        Me.lNim.TabIndex = 1
        Me.lNim.Text = "NIM"
        '
        'tbKonfKataSandi
        '
        Me.tbKonfKataSandi.Location = New System.Drawing.Point(18, 178)
        Me.tbKonfKataSandi.Name = "tbKonfKataSandi"
        Me.tbKonfKataSandi.Size = New System.Drawing.Size(156, 20)
        Me.tbKonfKataSandi.TabIndex = 2
        Me.tbKonfKataSandi.UseSystemPasswordChar = True
        '
        'tbKatSandiBaru
        '
        Me.tbKatSandiBaru.Location = New System.Drawing.Point(18, 131)
        Me.tbKatSandiBaru.Name = "tbKatSandiBaru"
        Me.tbKatSandiBaru.Size = New System.Drawing.Size(156, 20)
        Me.tbKatSandiBaru.TabIndex = 1
        Me.tbKatSandiBaru.UseSystemPasswordChar = True
        '
        'tbNimBaru
        '
        Me.tbNimBaru.Location = New System.Drawing.Point(18, 42)
        Me.tbNimBaru.Name = "tbNimBaru"
        Me.tbNimBaru.Size = New System.Drawing.Size(156, 20)
        Me.tbNimBaru.TabIndex = 0
        '
        'bDaftar
        '
        Me.bDaftar.Location = New System.Drawing.Point(18, 215)
        Me.bDaftar.Name = "bDaftar"
        Me.bDaftar.Size = New System.Drawing.Size(75, 23)
        Me.bDaftar.TabIndex = 3
        Me.bDaftar.Text = "&Daftar"
        Me.bDaftar.UseVisualStyleBackColor = True
        '
        'bBatal
        '
        Me.bBatal.Location = New System.Drawing.Point(99, 215)
        Me.bBatal.Name = "bBatal"
        Me.bBatal.Size = New System.Drawing.Size(75, 23)
        Me.bBatal.TabIndex = 4
        Me.bBatal.Text = "&Batal"
        Me.bBatal.UseVisualStyleBackColor = True
        '
        'tbNamaBaru
        '
        Me.tbNamaBaru.Location = New System.Drawing.Point(18, 86)
        Me.tbNamaBaru.Name = "tbNamaBaru"
        Me.tbNamaBaru.Size = New System.Drawing.Size(156, 20)
        Me.tbNamaBaru.TabIndex = 1
        '
        'lNamaLengkap
        '
        Me.lNamaLengkap.AutoSize = True
        Me.lNamaLengkap.Location = New System.Drawing.Point(15, 69)
        Me.lNamaLengkap.Name = "lNamaLengkap"
        Me.lNamaLengkap.Size = New System.Drawing.Size(80, 13)
        Me.lNamaLengkap.TabIndex = 1
        Me.lNamaLengkap.Text = "Nama Lengkap"
        '
        'FormDaftar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(219, 295)
        Me.Controls.Add(Me.gbTambahAkun)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDaftar"
        Me.Text = "Form Daftar"
        Me.gbTambahAkun.ResumeLayout(False)
        Me.gbTambahAkun.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbTambahAkun As System.Windows.Forms.GroupBox
    Friend WithEvents lKonfKataSandiBaru As System.Windows.Forms.Label
    Friend WithEvents lKataSandi As System.Windows.Forms.Label
    Friend WithEvents lNim As System.Windows.Forms.Label
    Friend WithEvents tbKonfKataSandi As System.Windows.Forms.TextBox
    Friend WithEvents tbKatSandiBaru As System.Windows.Forms.TextBox
    Friend WithEvents tbNimBaru As System.Windows.Forms.TextBox
    Friend WithEvents bDaftar As System.Windows.Forms.Button
    Friend WithEvents bBatal As System.Windows.Forms.Button
    Friend WithEvents lNamaLengkap As System.Windows.Forms.Label
    Friend WithEvents tbNamaBaru As System.Windows.Forms.TextBox
End Class
