Imports System.Collections.ObjectModel

Class MainWindow

    Private allFish As New ObservableCollection(Of Fish)

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' Add the fish!       Name        Biome        Active during   Best Spear    Bait                     Standing                   Meat                    Scales                  Oil        Special Part
        allFish.Add(New Fish("Charc Eel", Biomes.Lake, TimeOfDay.Both, Spears.Tulok, Baits.None, New FishSizes(25, 35, 50), New FishSizes(3, 3, 5), New FishSizes(2, 3, 4), New FishSizes(1, 2, 3), "Charc Electroplax"))
        allFish.Add(New Fish("Mawfish", Biomes.Lake, TimeOfDay.Day, Spears.Tulok, Baits.None, New FishSizes(25, 35, 50), New FishSizes(3, 4, 5), New FishSizes(3, 2, 3), New FishSizes(1, 3, 4), "Mawfish Bones"))
        allFish.Add(New Fish("Yogwun", Biomes.Landlocked, TimeOfDay.Day, Spears.Tulok, Baits.None, New FishSizes(25, 35, 50), New FishSizes(4, 5, 6), New FishSizes(1, 2, 3), New FishSizes(1, 2, 3), "Yogwun Stomach"))
        allFish.Add(New Fish("Khut-Khut", Biomes.Landlocked, TimeOfDay.Day, Spears.Peram, Baits.None, New FishSizes(25, 35, 50), New FishSizes(2, 3, 3), New FishSizes(1, 2, 3), New FishSizes(3, 4, 5), "Khut-Khut Venom Sac"))
        allFish.Add(New Fish("Goopolla", Biomes.Coastal, TimeOfDay.Both, Spears.Tulok, Baits.None, New FishSizes(25, 35, 50), New FishSizes(3, 3, 4), New FishSizes(2, 4, 5), New FishSizes(1, 2, 3), "Goopolla Spleen"))
        allFish.Add(New Fish("Mortus Lungfish", Biomes.Landlocked, TimeOfDay.Night, Spears.Peram, Baits.None, New FishSizes(100, 125, 200), New FishSizes(3, 4, 5), New FishSizes(1, 2, 3), New FishSizes(4, 6, 8), "Mortus Horn"))
        allFish.Add(New Fish("Tralok", Biomes.Coastal, TimeOfDay.Day, Spears.Tulok, Baits.None, New FishSizes(100, 125, 200), New FishSizes(2, 3, 4), New FishSizes(5, 7, 9), New FishSizes(1, 2, 3), "Tralok Eyes"))
        allFish.Add(New Fish("Cuthol", Biomes.Landlocked, TimeOfDay.Night, Spears.Lanzo, Baits.Cuthol, New FishSizes(500, 625, 100), New FishSizes(5, 8, 11), New FishSizes(3, 4, 5), New FishSizes(2, 3, 4), "Cuthol Tendrils"))
        allFish.Add(New Fish("Murkray", Biomes.Coastal, TimeOfDay.Both, Spears.Lanzo, Baits.Murkray, New FishSizes(500, 625, 1000), New FishSizes(1, 3, 5), New FishSizes(2, 4, 6), New FishSizes(7, 8, 9), "Murkray Liver"))
        allFish.Add(New Fish("Sharrac", Biomes.Coastal, TimeOfDay.Both, Spears.Lanzo, Baits.Twighlight, New FishSizes(100, 125, 200), New FishSizes(2, 3, 4), New FishSizes(4, 6, 8), New FishSizes(2, 3, 4), "Sharrac Teeth"))
        allFish.Add(New Fish("Karkina", Biomes.Coastal, TimeOfDay.Both, Spears.Tulok, Baits.Twighlight, New FishSizes(100, 125, 200), New FishSizes(1, 2, 3), New FishSizes(3, 4, 5), New FishSizes(4, 6, 8), "Karkina Antenna"))
        allFish.Add(New Fish("Glappid", Biomes.Coastal, TimeOfDay.Night, Spears.Peram, Baits.Glappid, New FishSizes(1200, 1500, 2000), New FishSizes(4, 6, 8), New FishSizes(5, 7, 9), New FishSizes(3, 5, 7), "Seram Beetle Shell"))
        allFish.Add(New Fish("Norg", Biomes.Lake, TimeOfDay.Night, Spears.Peram, Baits.Norg, New FishSizes(500, 625, 100), New FishSizes(2, 3, 4), New FishSizes(5, 7, 10), New FishSizes(3, 5, 6), "Norg Brain"))
    End Sub

End Class
