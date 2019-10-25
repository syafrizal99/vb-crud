<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLogin
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bMasuk = New System.Windows.Forms.Button()
        Me.tbKataSandi = New System.Windows.Forms.TextBox()
        Me.tbNim = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.bMasuk)
        Me.GroupBox1.Controls.Add(Me.tbKataSandi)
        Me.GroupBox1.Controls.Add(Me.tbNim)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(260, 180)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Akun Anda"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "NIM"
        '
        'bMasuk
        '
        Me.bMasuk.Location = New System.Drawing.Point(92, 127)
        Me.bMasuk.Name = "bMasuk"
        Me.bMasuk.Size = New System.Drawing.Size(75, 23)
        Me.bMasuk.TabIndex = 2
        Me.bMasuk.Text = "Masuk"
        Me.bMasuk.UseVisualStyleBackColor = True
        '
        'tbKataSandi
        '
        Me.tbKataSandi.Location = New System.Drawing.Point(15, 92)
        Me.tbKataSandi.Name = "tbKataSandi"
        Me.tbKataSandi.Size = New System.Drawing.Size(228, 20)
        Me.tbKataSandi.TabIndex = 1
        Me.tbKataSandi.UseSystemPasswordChar = True
        '
        'tbNim
        '
        Me.tbNim.Location = New System.Drawing.Point(15, 46)
        Me.tbNim.Name = "tbNim"
        Me.tbNim.Size = New System.Drawing.Size(228, 20)
        Me.tbNim.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Kata Sandi"
        '
        'FormLogin
        '
        Me.AcceptButton = Me.bMasuk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 211)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FormLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormLogin"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents bMasuk As System.Windows.Forms.Button
    Friend WithEvents tbKataSandi As System.Windows.Forms.TextBox
    Friend WithEvents tbNim As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
