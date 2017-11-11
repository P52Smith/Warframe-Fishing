Public Enum Spears
    Lanzo
    Tulok
    Peram
End Enum

Public Enum Biomes
    Lake
    Landlocked
    Coastal
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

Public Interface IFishSizes
    Property Small As UInteger
    Property Medium As UInteger
    Property Large As UInteger
End Interface

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
    ReadOnly Property Spear As Spears
    ReadOnly Property Bait As Baits
    ReadOnly Property Products As IFishParts
    Property Caught As IFishSizes
    ReadOnly Property ProductsAvailable As IFishParts
End Interface
