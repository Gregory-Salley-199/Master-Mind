Public Class Form1

    Dim colors() As String = New String() {"Red", "Green", "Blue", "Yellow"}

    Dim scoreLine() As pegPlace
    Public lines(,) As pegPlace

    Public lineIndex As Integer = 11

    Dim r As New Random
    Dim winningLine() As String

    Private Structure feedback
        Dim black As Integer
        Dim red As Integer
    End Structure

    Dim clues(11) As feedback

    Dim level As Integer = 4

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.DrawLine(New Pen(Brushes.Black, 3), 12, 65, Me.ClientSize.Width - 12, 65)
        Dim positions() As Point = If(level = 6, {New Point(8, 2), New Point(13, 2), New Point(18, 2), New Point(8, 7), New Point(13, 7), New Point(18, 7)}, _
                                                  If(level = 5, {New Point(8, 2), New Point(13, 2), New Point(18, 5), New Point(8, 7), New Point(13, 7)}, _
                                                {New Point(8, 2), New Point(13, 2), New Point(8, 7), New Point(13, 7)}))
        For y As Integer = 11 To 0 Step -1
            If Not lines(y, 0).Visible Then Continue For
            For x As Integer = 1 To level
                Dim fillColor As Color = Nothing
                If x <= clues(y).black Then
                    fillColor = Color.Black
                Else
                    If x <= clues(y).black + clues(y).red Then
                        fillColor = Color.Red
                    End If
                End If

                If Not fillColor = Nothing Then
                    e.Graphics.FillEllipse(New SolidBrush(fillColor), New Rectangle(lines(y, level - 1).Right + positions(x - 1).X, lines(y, level - 1).Top + positions(x - 1).Y + 2, 3, 3))
                End If
                e.Graphics.DrawEllipse(Pens.Black, New Rectangle(lines(y, level - 1).Right + positions(x - 1).X, lines(y, level - 1).Top + positions(x - 1).Y + 2, 3, 3))
            Next
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripComboBox1.Items.AddRange(New String() {"Beginner", "Intermediate", "Advanced"})

        scoreLine = New pegPlace() {PegPlace1, PegPlace2, PegPlace3, PegPlace4, PegPlace37, PegPlace38}
        lines = New pegPlace(,) {{PegPlace5, PegPlace6, PegPlace7, PegPlace8, PegPlace39, PegPlace40}, _
                                   {PegPlace9, PegPlace10, PegPlace11, PegPlace12, PegPlace41, PegPlace42}, _
                                   {PegPlace13, PegPlace14, PegPlace15, PegPlace16, PegPlace43, PegPlace44}, _
                                   {PegPlace17, PegPlace18, PegPlace19, PegPlace20, PegPlace45, PegPlace46}, _
                                   {PegPlace21, PegPlace22, PegPlace23, PegPlace24, PegPlace47, PegPlace48}, _
                                   {PegPlace25, PegPlace26, PegPlace27, PegPlace28, PegPlace49, PegPlace50}, _
                                   {PegPlace29, PegPlace30, PegPlace31, PegPlace32, PegPlace51, PegPlace52}, _
                                   {PegPlace33, PegPlace34, PegPlace35, PegPlace36, PegPlace53, PegPlace54}, _
                                   {PegPlace55, PegPlace56, PegPlace57, PegPlace58, PegPlace59, PegPlace60}, _
                                   {PegPlace61, PegPlace62, PegPlace63, PegPlace64, PegPlace65, PegPlace66}, _
                                   {PegPlace67, PegPlace68, PegPlace69, PegPlace70, PegPlace71, PegPlace72}, _
                                   {PegPlace73, PegPlace74, PegPlace75, PegPlace76, PegPlace77, PegPlace78}}

        For y As Integer = 0 To 11
            For x As Integer = 0 To 5
                AddHandler lines(y, x).colorSelected, AddressOf pp_colorSelected
            Next
        Next

        ToolStripComboBox1.SelectedIndex = 0

    End Sub

    Private Sub pp_colorSelected(sender As Object)
        For y As Integer = 0 To 11
            For x As Integer = 0 To 5
                If sender Is lines(y, x) Then
                    Dim line() As String = Array.ConvertAll(Enumerable.Range(0, level).Select(Function(i) lines(y, i)).ToArray, Function(pp) pp.pegColor.Name)
                    btnCheck.Enabled = line.All(Function(s) colors.Contains(s))
                End If
            Next
        Next
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Dim line() As pegPlace = Enumerable.Range(0, level).Select(Function(x) lines(lineIndex, x)).ToArray
        Dim lineColors() As String = Array.ConvertAll(line, Function(pp) pp.pegColor.Name)
        clues(lineIndex) = New feedback
        clues(lineIndex).black = Enumerable.Range(0, level).Count(Function(x) winningLine(x) = lineColors(x))

        Dim tempArray() As String = DirectCast(winningLine.Clone, String())
        For x As Integer = 0 To level - 1
            If tempArray(x) = lineColors(x) Then
                lineColors(x) = "z"
                tempArray(x) = "z"
            End If
        Next

        clues(lineIndex).red = 0
        For x As Integer = 0 To level - 1
            Dim i As Integer = Array.FindIndex(lineColors, Function(c) tempArray(x) <> "z" AndAlso tempArray(x) = c)
            If i > -1 Then
                lineColors(i) = "z"
                tempArray(x) = "z"
                clues(lineIndex).red += 1
            End If
        Next

        Me.Invalidate()

        If clues(lineIndex).black = level Then
            MsgBox("You've won!")
            lineIndex = -1
            broadcastCMSEnabled(lineIndex)
            btnNew.Enabled = True
            btnCheck.Enabled = False
        Else
            btnCheck.Enabled = False
            lineIndex -= 1
            broadcastCMSEnabled(lineIndex)
            If lineIndex = -1 Then
                MsgBox("You've lost!")
                btnNew.Enabled = True
            Else
                Return
            End If
        End If

        For x As Integer = 0 To level - 1
            scoreLine(x).pegColor = Color.FromName(winningLine(x))
            scoreLine(x).Invalidate()
        Next

    End Sub

    Private Sub broadcastCMSEnabled(index As Integer)
        For y As Integer = 0 To 11
            For x As Integer = 0 To 5
                lines(y, x).CMSEnabled = (y = index)
            Next
        Next
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        newGame()
    End Sub

    Private Sub newGame()
        winningLine = Enumerable.Range(0, level).Select(Function(x) colors(r.Next(0, 4))).ToArray
        lineIndex = (level * 2) - 1
        broadcastCMSEnabled(lineIndex)

        Erase clues
        ReDim clues(11)
        For x As Integer = 0 To 5
            scoreLine(x).reset()
        Next
        For y As Integer = 0 To 11
            For x As Integer = 0 To 5
                lines(y, x).reset()
            Next
        Next

        btnNew.Enabled = False
        Me.Invalidate()
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        level = ToolStripComboBox1.SelectedIndex + 4
        Dim levelSizes() As Size = {New Size(154, 329), New Size(176, 373), New Size(192, 416)}
        Me.SetClientSizeCore(levelSizes(level - 4).Width, levelSizes(level - 4).Height)
        For x As Integer = 0 To 5
            scoreLine(x).Visible = (x < level)
        Next
        For y As Integer = 0 To 11
            For x As Integer = 0 To 5
                lines(y, x).Visible = (y < level * 2) AndAlso (x < level)
            Next
        Next
        newGame()
    End Sub

End Class
