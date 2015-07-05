<System.Serializable()> Public Class UnoCard
    Enum Colors
        BLUE
        RED
        GREEN
        YELLOW
        BLACK
        WHITE
    End Enum
    Enum Types
        ZERO
        ONE
        TWO
        THREE
        FOUR
        FIVE
        SIX
        SEVEN
        EIGHT
        NINE
        DRAWTWO
        REVERSE
        SKIP
        WILD
        WILDDRAWFOUR
        BLANK
    End Enum

    Public color As Colors = Colors.BLUE
    Public type As Types = Types.ZERO
    Public newcolor As Colors = Colors.WHITE

    Public Sub New(ByVal nr As Integer)
        SetCard(nr)
    End Sub
    Public Sub Draw(ByVal graphics As System.Drawing.Graphics)

    End Sub

    Public Sub SetCard(ByVal i As Byte)
        Me.color = i \ 25
        Dim typenr As Byte
        typenr = i Mod 25
        If (color = Colors.BLACK) Then
            If typenr < 4 Then
                type = Types.WILD
            ElseIf typenr < 8 Then
                type = Types.WILDDRAWFOUR
            Else
                color = Colors.WHITE
            End If
        Else
            If (typenr < 1) Then
                type = Types.ZERO
            Else
                typenr += 1
                type = typenr \ 2
            End If
        End If
        If color = Colors.WHITE Then
            Throw New Exception("Wrong number as argument in setcard")
        End If
    End Sub
    Public Function SetNewColor(ByVal color As Colors) As Boolean
        If Me.type = Types.WILD Or Me.type = Types.WILDDRAWFOUR Then
            If color = Colors.BLUE Or color = Colors.GREEN Or color = Colors.RED Or color = Colors.YELLOW Then
                Me.newcolor = color
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function
    Public Function GetNewColor() As Colors
        Return Me.newcolor
    End Function
    Public Function IsValidCard() As Boolean
        '    If Me.color Is Nothing Or Me.type Is Nothing Then
        'Return False
        '   End If
        If Me.color = Colors.BLUE Or Me.color = Colors.GREEN Or Me.color = Colors.RED Or Me.color = Colors.YELLOW Then
            If Me.type = Types.BLANK Or Me.type = Types.WILD Or Me.type = Types.WILDDRAWFOUR Then
                Return False
            End If
            Return True
        ElseIf Me.color = Colors.BLACK Then
            If Me.type = Types.WILD Or Me.type = Types.WILDDRAWFOUR Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Public ReadOnly Property Value() As Byte
        Get
            Select Case Me.type
                Case Types.BLANK
                    Return 0
                Case Types.WILD Or Types.WILDDRAWFOUR
                    Return 50
                Case Types.DRAWTWO Or Types.REVERSE Or Types.SKIP
                    Return 20
                Case Types.ZERO
                    Return 0
                Case Types.ONE
                    Return 1
                Case Types.TWO
                    Return 2
                Case Types.THREE
                    Return 3
                Case Types.FOUR
                    Return 4
                Case Types.FIVE
                    Return 5
                Case Types.SIX
                    Return 6
                Case Types.SEVEN
                    Return 7
                Case Types.EIGHT
                    Return 8
                Case Types.NINE
                    Return 9
            End Select
        End Get
    End Property
End Class
