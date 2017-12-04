Imports System.Collections.ObjectModel
Imports System.ComponentModel

Class MainWindow
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Property AllFish As New ObservableCollection(Of Fish)

    Private activeColumn As GridViewColumnHeader
    Private ourSortAdorner As SortAdorner
    Private activeSortGroup As MenuItem = Nothing

    Private _ResourceBoosterMode As Boolean = False
    Public Property ResourceBoosterMode As Boolean
        Get
            Return _ResourceBoosterMode
        End Get
        Set(value As Boolean)
            If _ResourceBoosterMode <> value Then
                _ResourceBoosterMode = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(ResourceBoosterMode)))
            End If
        End Set
    End Property

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' Update title
        Title += $" - {Application.appVersion}"
        ' Add the fish!       Name        Biome        Active during   Best Spear    Bait                     Standing                   Meat                    Scales                  Oil        Special Part
        AllFish.Add(New Fish("Charc Eel", Biomes.Lake, TimeOfDay.Both, Spears.Tulok, Baits.None, New FishSizes(25, 35, 50), New FishSizes(3, 3, 5), New FishSizes(2, 3, 4), New FishSizes(1, 2, 3), "Charc Electroplax"))
        AllFish.Add(New Fish("Mawfish", Biomes.Lake, TimeOfDay.Day, Spears.Tulok, Baits.None, New FishSizes(25, 35, 50), New FishSizes(3, 4, 5), New FishSizes(3, 2, 3), New FishSizes(1, 3, 4), "Mawfish Bones"))
        AllFish.Add(New Fish("Yogwun", Biomes.Landlocked, TimeOfDay.Day, Spears.Tulok, Baits.None, New FishSizes(25, 35, 50), New FishSizes(4, 5, 6), New FishSizes(1, 2, 3), New FishSizes(1, 2, 3), "Yogwun Stomach"))
        AllFish.Add(New Fish("Khut-Khut", Biomes.Landlocked, TimeOfDay.Day, Spears.Peram, Baits.None, New FishSizes(25, 35, 50), New FishSizes(2, 3, 3), New FishSizes(1, 2, 3), New FishSizes(3, 4, 5), "Khut-Khut Venom Sac"))
        AllFish.Add(New Fish("Goopolla", Biomes.Coastal, TimeOfDay.Both, Spears.Tulok, Baits.None, New FishSizes(25, 35, 50), New FishSizes(3, 3, 4), New FishSizes(2, 4, 5), New FishSizes(1, 2, 3), "Goopolla Spleen"))
        AllFish.Add(New Fish("Mortus Lungfish", Biomes.Landlocked, TimeOfDay.Night, Spears.Peram, Baits.None, New FishSizes(100, 125, 200), New FishSizes(3, 4, 5), New FishSizes(1, 2, 3), New FishSizes(4, 6, 8), "Mortus Horn"))
        AllFish.Add(New Fish("Tralok", Biomes.Coastal, TimeOfDay.Day, Spears.Tulok, Baits.None, New FishSizes(100, 125, 200), New FishSizes(2, 3, 4), New FishSizes(5, 7, 9), New FishSizes(1, 2, 3), "Tralok Eyes"))
        AllFish.Add(New Fish("Cuthol", Biomes.Landlocked, TimeOfDay.Night, Spears.Lanzo, Baits.Cuthol, New FishSizes(500, 625, 100), New FishSizes(5, 8, 11), New FishSizes(3, 4, 5), New FishSizes(2, 3, 4), "Cuthol Tendrils"))
        AllFish.Add(New Fish("Murkray", Biomes.Coastal, TimeOfDay.Both, Spears.Lanzo, Baits.Murkray, New FishSizes(500, 625, 1000), New FishSizes(1, 3, 5), New FishSizes(2, 4, 6), New FishSizes(7, 8, 9), "Murkray Liver"))
        AllFish.Add(New Fish("Sharrac", Biomes.Coastal, TimeOfDay.Both, Spears.Lanzo, Baits.Twighlight, New FishSizes(100, 125, 200), New FishSizes(2, 3, 4), New FishSizes(4, 6, 8), New FishSizes(2, 3, 4), "Sharrac Teeth"))
        AllFish.Add(New Fish("Karkina", Biomes.Coastal, TimeOfDay.Both, Spears.Tulok, Baits.Twighlight, New FishSizes(100, 125, 200), New FishSizes(1, 2, 3), New FishSizes(3, 4, 5), New FishSizes(4, 6, 8), "Karkina Antenna"))
        AllFish.Add(New Fish("Glappid", Biomes.Coastal, TimeOfDay.Night, Spears.Peram, Baits.Glappid, New FishSizes(1200, 1500, 2000), New FishSizes(4, 6, 8), New FishSizes(5, 7, 9), New FishSizes(3, 5, 7), "Seram Beetle Shell"))
        AllFish.Add(New Fish("Norg", Biomes.Lake, TimeOfDay.Night, Spears.Peram, Baits.Norg, New FishSizes(500, 625, 100), New FishSizes(2, 3, 4), New FishSizes(5, 7, 10), New FishSizes(3, 5, 6), "Norg Brain"))
    End Sub

    Private Sub CaughtSmall_Subtract_Click(sender As Primitives.RepeatButton, e As RoutedEventArgs)
        Dim theFish As Fish = sender.DataContext
        If theFish.Caught.Small > If(ResourceBoosterMode, 1, 0) Then
            theFish.Caught.Small -= If(ResourceBoosterMode, 2, 1)
        Else
            theFish.Caught.Small = 0
        End If
    End Sub

    Private Sub CaughtSmall_Add_Click(sender As Primitives.RepeatButton, e As RoutedEventArgs)
        Dim theFish As Fish = sender.DataContext
        If theFish.Caught.Small < If(ResourceBoosterMode, UInteger.MaxValue - 1, UInteger.MaxValue) Then
            theFish.Caught.Small += If(ResourceBoosterMode, 2, 1)
        Else
            theFish.Caught.Small = UInteger.MaxValue
        End If
    End Sub

    Private Sub CaughtMedium_Subtract_Click(sender As Primitives.RepeatButton, e As RoutedEventArgs)
        Dim theFish As Fish = sender.DataContext
        If theFish.Caught.Medium > If(ResourceBoosterMode, 1, 0) Then
            theFish.Caught.Medium -= If(ResourceBoosterMode, 2, 1)
        Else
            theFish.Caught.Medium = 0
        End If
    End Sub

    Private Sub CaughtMedium_Add_Click(sender As Primitives.RepeatButton, e As RoutedEventArgs)
        Dim theFish As Fish = sender.DataContext
        If theFish.Caught.Medium < If(ResourceBoosterMode, UInteger.MaxValue - 1, UInteger.MaxValue) Then
            theFish.Caught.Medium += If(ResourceBoosterMode, 2, 1)
        Else
            theFish.Caught.Medium = UInteger.MaxValue
        End If
    End Sub

    Private Sub CaughtLarge_Subtract_Click(sender As Primitives.RepeatButton, e As RoutedEventArgs)
        Dim theFish As Fish = sender.DataContext
        If theFish.Caught.Large > If(ResourceBoosterMode, 1, 0) Then
            theFish.Caught.Large -= If(ResourceBoosterMode, 2, 1)
        Else
            theFish.Caught.Large = 0
        End If
    End Sub

    Private Sub CaughtLarge_Add_Click(sender As Primitives.RepeatButton, e As RoutedEventArgs)
        Dim theFish As Fish = sender.DataContext
        If theFish.Caught.Large < If(ResourceBoosterMode, UInteger.MaxValue - 1, UInteger.MaxValue) Then
            theFish.Caught.Large += If(ResourceBoosterMode, 2, 1)
        Else
            theFish.Caught.Large = UInteger.MaxValue
        End If
    End Sub

    Private Sub FishListColumnHeader_Click(sender As Object, e As RoutedEventArgs)
        Dim column As GridViewColumnHeader = CType(sender, GridViewColumnHeader)
        Dim sortBy As String = column.Tag.ToString
        If activeColumn IsNot Nothing Then
            AdornerLayer.GetAdornerLayer(activeColumn).Remove(ourSortAdorner)
            FishView.Items.SortDescriptions.Clear()
        End If
        Dim newDir As ListSortDirection = ListSortDirection.Ascending
        If (activeColumn Is column) AndAlso (ourSortAdorner.Direction = newDir) Then
            newDir = ListSortDirection.Descending
        End If
        activeColumn = column
        ourSortAdorner = New SortAdorner(activeColumn, newDir)
        AdornerLayer.GetAdornerLayer(activeColumn).Add(ourSortAdorner)
        FishView.Items.SortDescriptions.Add(New SortDescription(sortBy, newDir))
    End Sub

    Public Class SortAdorner
        Inherits Adorner

        Private Shared ascGeometry As Geometry = Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z")
        Private Shared descGeometry As Geometry = Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z")

        Public Property Direction As ListSortDirection

        Public Sub New(element As UIElement, dir As ListSortDirection)
            MyBase.New(element)
            Me.Direction = dir
        End Sub

        Protected Overrides Sub OnRender(drawingContext As DrawingContext)
            MyBase.OnRender(drawingContext)
            If AdornedElement.RenderSize.Width < 20 Then
                Return
            End If
            Dim Transform As TranslateTransform = New TranslateTransform(
                                        AdornedElement.RenderSize.Width - 15,
                                        (AdornedElement.RenderSize.Height - 5) / 2)
            drawingContext.PushTransform(Transform)
            Dim Geometry As Geometry = ascGeometry
            If (Me.Direction = ListSortDirection.Descending) Then
                Geometry = descGeometry
            End If
            drawingContext.DrawGeometry(Brushes.Black, Nothing, Geometry)
            drawingContext.Pop()
        End Sub
    End Class

    Private Sub FishListGroup_Click(sender As MenuItem, e As RoutedEventArgs)
        Dim theView As CollectionView = CollectionViewSource.GetDefaultView(FishView.ItemsSource)
        If activeSortGroup IsNot sender Then
            If activeSortGroup IsNot Nothing Then
                activeSortGroup.IsChecked = False
            End If
            Dim groupDescription As PropertyGroupDescription
            Select Case sender.Name
                Case FishView_Group_Biome.Name
                    groupDescription = New PropertyGroupDescription("Biome")
                Case FishView_Group_ActiveTime.Name
                    groupDescription = New PropertyGroupDescription("ActiveTime")
                Case FishView_Group_Spear.Name
                    groupDescription = New PropertyGroupDescription("Spear")
                Case Else
                    Return
            End Select
            theView.GroupDescriptions.Clear()
            theView.GroupDescriptions.Add(groupDescription)
            activeSortGroup = sender
            activeSortGroup.IsChecked = True
        Else
            theView.GroupDescriptions.Clear()
            If activeSortGroup IsNot Nothing Then
                activeSortGroup.IsChecked = False
            End If
            activeSortGroup = Nothing
        End If
    End Sub
End Class
