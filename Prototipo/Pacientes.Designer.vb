<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pacientes
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
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dg_pacientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dg_pacientes
        '
        Me.dg_pacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_pacientes.Location = New System.Drawing.Point(12, 12)
        Me.dg_pacientes.Name = "dg_pacientes"
        Me.dg_pacientes.Size = New System.Drawing.Size(890, 475)
        Me.dg_pacientes.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(811, 502)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Agregar Dato"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Pacientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 537)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dg_pacientes)
        Me.Name = "Pacientes"
        Me.Text = "Pacientes"
        CType(Me.dg_pacientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dg_pacientes As DataGridView
    Friend WithEvents Button1 As Button
End Class
