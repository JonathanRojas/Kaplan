<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Exportacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dg_pacientes = New System.Windows.Forms.DataGridView()
        Me.btn_exportar = New System.Windows.Forms.Button()
        Me.bar_progreso = New System.Windows.Forms.ProgressBar()
        Me.lbl_total = New System.Windows.Forms.Label()
        CType(Me.dg_pacientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dg_pacientes
        '
        Me.dg_pacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_pacientes.Location = New System.Drawing.Point(4, 4)
        Me.dg_pacientes.Name = "dg_pacientes"
        Me.dg_pacientes.Size = New System.Drawing.Size(387, 182)
        Me.dg_pacientes.TabIndex = 0
        '
        'btn_exportar
        '
        Me.btn_exportar.Location = New System.Drawing.Point(300, 192)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(91, 23)
        Me.btn_exportar.TabIndex = 1
        Me.btn_exportar.Text = "Exportar Data"
        Me.btn_exportar.UseVisualStyleBackColor = True
        '
        'bar_progreso
        '
        Me.bar_progreso.Location = New System.Drawing.Point(4, 192)
        Me.bar_progreso.Name = "bar_progreso"
        Me.bar_progreso.Size = New System.Drawing.Size(290, 23)
        Me.bar_progreso.TabIndex = 2
        '
        'lbl_total
        '
        Me.lbl_total.AutoSize = True
        Me.lbl_total.Location = New System.Drawing.Point(1, 218)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(0, 13)
        Me.lbl_total.TabIndex = 3
        '
        'Exportacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 241)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.bar_progreso)
        Me.Controls.Add(Me.btn_exportar)
        Me.Controls.Add(Me.dg_pacientes)
        Me.Name = "Exportacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportación de datos"
        CType(Me.dg_pacientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dg_pacientes As DataGridView
    Friend WithEvents btn_exportar As Button
    Friend WithEvents bar_progreso As ProgressBar
    Friend WithEvents lbl_total As Label
End Class
