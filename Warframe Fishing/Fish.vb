Imports System.ComponentModel
Imports Warframe_Fishing

Public Class Fish
    Implements IFish, INotifyPropertyChanged

    Private Class _FishProducts
        Implements IFishParts

        Private _standing As FishSizes
        Private _meat As FishSizes
        Private _scales As FishSizes
        Private _oil As FishSizes
        Private _special As FishSizes
        Private _specialName As String = "Unknown"

        Public ReadOnly Property Standing As IFishSizes Implements IFishParts.Standing
            Get
                Return _standing
            End Get
        End Property

        Public ReadOnly Property Meat As IFishSizes Implements IFishParts.Meat
            Get
                Return _meat
            End Get
        End Property

        Public ReadOnly Property Scales As IFishSizes Implements IFishParts.Scales
            Get
                Return _scales
            End Get
        End Property

        Public ReadOnly Property Oil As IFishSizes Implements IFishParts.Oil
            Get
                Return _oil
            End Get
        End Property

        Public ReadOnly Property Special As IFishSizes Implements IFishParts.Special
            Get
                Return _special
            End Get
        End Property

        Public ReadOnly Property SpecialName As String Implements IFishParts.SpecialName
            Get
                Return _specialName
            End Get
        End Property

        Public Sub New(theStanding As FishSizes, theMeat As FishSizes, theScales As FishSizes, theOil As FishSizes, theSpecial As String)
            _standing = theStanding
            _meat = theMeat
            _scales = theScales
            _oil = theOil
            _special = New FishSizes(1, 1, 1)
            _specialName = theSpecial
        End Sub
    End Class
    Private Class _FishParts
        Implements IFishParts, INotifyPropertyChanged

        Private ourFish As Fish
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Public ReadOnly Property Standing As IFishSizes Implements IFishParts.Standing
            Get
                Return ourFish.Caught * ourFish.Products.Standing
            End Get
        End Property

        Public ReadOnly Property Meat As IFishSizes Implements IFishParts.Meat
            Get
                Return ourFish.Caught * ourFish.Products.Meat
            End Get
        End Property

        Public ReadOnly Property Scales As IFishSizes Implements IFishParts.Scales
            Get
                Return ourFish.Caught * ourFish.Products.Scales
            End Get
        End Property

        Public ReadOnly Property Oil As IFishSizes Implements IFishParts.Oil
            Get
                Return ourFish.Caught * ourFish.Products.Oil
            End Get
        End Property

        Public ReadOnly Property Special As IFishSizes Implements IFishParts.Special
            Get
                Return ourFish.Caught * ourFish.Products.Special
            End Get
        End Property

        Public ReadOnly Property SpecialName As String Implements IFishParts.SpecialName
            Get
                Return ourFish.Products.SpecialName
            End Get
        End Property

        Public Sub New(theFish As Fish)
            ourFish = theFish
            AddHandler ourFish.Caught.PropertyChanged, Sub()
                                                           RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Standing)))
                                                           RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Meat)))
                                                           RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Scales)))
                                                           RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Oil)))
                                                           RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Special)))
                                                       End Sub
        End Sub
    End Class
    Private _name As String = "Unknown"
    Private _biome As Biomes
    Private _activeTime As TimeOfDay
    Private _spear As Spears
    Private _bait As Baits = Baits.None
    Private _products As _FishProducts
    Private _caught As New FishSizes(0, 0, 0)
    Private _productsAvailable As New _FishParts(Me)
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public ReadOnly Property Name As String Implements IFish.Name
        Get
            Return _name
        End Get
    End Property

    Public ReadOnly Property Biome As Biomes Implements IFish.Biome
        Get
            Return _biome
        End Get
    End Property

    Public ReadOnly Property ActiveTime As TimeOfDay Implements IFish.ActiveTime
        Get
            Return _activeTime
        End Get
    End Property

    Public ReadOnly Property Spear As Spears Implements IFish.Spear
        Get
            Return _spear
        End Get
    End Property

    Public ReadOnly Property Bait As Baits Implements IFish.Bait
        Get
            Return _bait
        End Get
    End Property

    Public ReadOnly Property Products As IFishParts Implements IFish.Products
        Get
            Return _products
        End Get
    End Property

    Public Property Caught As FishSizes Implements IFish.Caught
        Get
            Return _caught
        End Get
        Set(value As FishSizes)
            _caught = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(ProductsAvailable)))
        End Set
    End Property

    Public ReadOnly Property ProductsAvailable As IFishParts Implements IFish.ProductsAvailable
        Get
            Return _productsAvailable
        End Get
    End Property

    Public Sub New(theName As String, theBiome As Biomes, theActiveTime As TimeOfDay, theSpear As Spears, theBait As Baits, theStanding As FishSizes, theMeat As FishSizes, theScales As FishSizes, theOil As FishSizes, theSpecialPartName As String)
        _name = theName
        _biome = theBiome
        _activeTime = theActiveTime
        _spear = theSpear
        _products = New _FishProducts(theStanding, theMeat, theScales, theOil, theSpecialPartName)
    End Sub
End Class
