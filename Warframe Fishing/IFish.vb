Imports System.ComponentModel

Public Enum Spears
    Lanzo
    Tulok
    Peram
End Enum

Public Enum Biomes
    Coastal
    Lake
    Landlocked
End Enum

Public Enum Baits
    None
    Peppered
    Twighlight
    Murkray
    Norg
    Cuthol
    Glappid
End Enum

Public Enum TimeOfDay
    Day
    Both
    Night
End Enum

Public Interface IFishSizes
    ReadOnly Property Small As UInteger
    ReadOnly Property Medium As UInteger
    ReadOnly Property Large As UInteger
    ReadOnly Property Total As UInteger
End Interface

Public Class FishSizes
    Implements IFishSizes, INotifyPropertyChanged

    Private _small As UInteger = 0
    Private _medium As UInteger = 0
    Private _large As UInteger = 0

    Public Property Small As UInteger Implements IFishSizes.Small
        Get
            Return _small
        End Get
        Set(value As UInteger)
            If _small <> value Then
                _small = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Small)))
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Total)))
            End If
        End Set
    End Property

    Public Property Medium As UInteger Implements IFishSizes.Medium
        Get
            Return _medium
        End Get
        Set(value As UInteger)
            If _medium <> value Then
                _medium = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Medium)))
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Total)))
            End If
        End Set
    End Property

    Public Property Large As UInteger Implements IFishSizes.Large
        Get
            Return _large
        End Get
        Set(value As UInteger)
            If _large <> value Then
                _large = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Large)))
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Total)))
            End If
        End Set
    End Property

    Public ReadOnly Property Total As UInteger Implements IFishSizes.Total
        Get
            Return Small + Medium + Large
        End Get
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub New(small As UInteger, medium As UInteger, large As UInteger)
        Me.Small = small
        Me.Medium = medium
        Me.Large = large
    End Sub

    Public Shared Operator *(ByVal caught As FishSizes, ByVal base As IFishSizes) As IFishSizes
        Return New FishSizes(caught.Small * base.Small, caught.Medium * base.Medium, caught.Large * base.Large)
    End Operator
End Class


Public Interface IFishParts
    ReadOnly Property Standing As IFishSizes
    ReadOnly Property Meat As IFishSizes
    ReadOnly Property Scales As IFishSizes
    ReadOnly Property Oil As IFishSizes
    ReadOnly Property Special As IFishSizes
    ReadOnly Property SpecialName As String
End Interface

Public Interface IFish
    ReadOnly Property Name As String
    ReadOnly Property Biome As Biomes
    ReadOnly Property ActiveTime As TimeOfDay
    ReadOnly Property Spear As Spears
    ReadOnly Property Bait As Baits
    ReadOnly Property Products As IFishParts
    Property Caught As FishSizes
    ReadOnly Property ProductsAvailable As IFishParts
End Interface
