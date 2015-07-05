<System.Serializable()> Public Class CurrColorChangedByWildCard
    Inherits GameSendData
    Public color As UnoCard.Colors
    Public Sub New(ByVal color As UnoCard.Colors)
        Me.color = color
    End Sub
    Public ReadOnly Property ColorName() As String
        Get
            Select Case color
                Case UnoCard.Colors.BLACK
                    Return "zwart"
                Case UnoCard.Colors.BLUE
                    Return "blauw"
                Case UnoCard.Colors.GREEN
                    Return "groen"
                Case UnoCard.Colors.RED
                    Return "rood"
                Case UnoCard.Colors.WHITE
                    Return "wit"
                Case UnoCard.Colors.YELLOW
                    Return "geel"
                Case Else
                    Return "fout"
            End Select
        End Get
    End Property
End Class
