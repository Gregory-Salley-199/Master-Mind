Public Class pegPlace
    Inherits Control

    Private WithEvents cms As New ContextMenuStrip

    Public Property pegColor As Color = SystemColors.Control
    Public Property CMSEnabled As Boolean

    Public Event colorSelected(sender As Object)

    Public Sub New()
        Me.Size = New Size(16, 16)
        Me.ContextMenuStrip = Me.cms
        Me.cms.Items.AddRange(Array.ConvertAll(Of String, ToolStripMenuItem)(New String() {"Red", "Green", "Blue", "Yellow"}, Function(s) New ToolStripMenuItem(s, Nothing, AddressOf itemClicked)))
    End Sub

    Public Sub reset()
        Me.pegColor = SystemColors.Control
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        Dim fillColor As Color = Color.FromName(Me.pegColor.Name.Replace("Green", "LimeGreen").Replace("Blue", "RoyalBlue"))
        pe.Graphics.FillEllipse(New SolidBrush(fillColor), New Rectangle(0, 0, 15, 15))
        pe.Graphics.DrawEllipse(Pens.Black, New Rectangle(0, 0, 15, 15))
        MyBase.OnPaint(pe)
    End Sub

    Private Sub itemClicked(sender As Object, e As EventArgs)
        Dim c As String = DirectCast(sender, ToolStripMenuItem).Text
        Me.pegColor = Color.FromName(c)
        Me.Invalidate()
        RaiseEvent colorSelected(Me)
    End Sub

    Private Sub cms_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cms.Opening
        e.Cancel = Not Me.CMSEnabled
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If Not Me.CMSEnabled OrElse e.Button <> Windows.Forms.MouseButtons.Left Then Return
        Dim colors() As String = {"Red", "Green", "Blue", "Yellow"}
        Dim index As Integer = Array.IndexOf(colors, Me.pegColor.Name) + 1
        Me.pegColor = Color.FromName(colors(index Mod 4))
        Me.Invalidate()
        RaiseEvent colorSelected(Me)
    End Sub

End Class
