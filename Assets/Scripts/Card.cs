using System.Collections.Generic;

/*
 Card Name	Artist	Buff
The Kiss	Gustav Klimt	Charm
Die Heimsuchung	Rembrandt van Rijn	Weakened
Porträt eines alten schlafenden Mannes	Rembrandt van Rijn	Sleeping
Der Kentaur Chiron und Achill	Giuseppe Maria Crespi	Weakened
Bildnis des Prinzen Eugen von Savoyen	Johann Gottfried Auerbach	Sublime
Elisabeth Christine von Braunschweig-Wolfenbüttel	Johann Gottfried Auerbach	Charm
Prinz Eugen von Savoyen als Feldherr	Johann Gottfried Auerbach	Sublime
		
Attack		Attack
Deffense		Defense
Taunt/Discourage		Taunt
 */

public class Card
{
    public string Name;
    public List<Effect> Effects;
    public string Description;
    public Artist Artist;
}

public class Cards
{
    public static Card TheKiss = new()
    {
        Name = "The Kiss",
        Description = "A painting by the Austrian symbolist painter Gustav Klimt.",
        Artist = Artists.Klimt,
        Effects = new List<Effect>()
        {
            Effects.Charm
        }
    };

    public static Card Heimsuchung = new()
    {
        Name = "Die Heimsuchung",
        Artist = Artists.Rembrandt,
        Description = "A painting by the Dutch draughtsman, painter, and printmaker Rembrandt van Rijn.",
        Effects = new List<Effect>()
        {
            Effects.Weaken
        }
    };
    
    public static Card SleepingManPortrait = new()
    {
        Name = "Porträt eines alten schlafenden Mannes",
        Artist = Artists.Rembrandt,
        Description = "A painting by the Dutch draughtsman, painter, and printmaker Rembrandt van Rijn.",
        Effects = new List<Effect>()
        {
            Effects.Sleep
        }
    };
    
    public static Card ChironAndAchill = new()
    {
        Name = "Der Kentaur Chiron und Achill",
        Artist = Artists.Crespi,
        Description = "A painting by the Italian late Baroque painter of the Bolognese School Giuseppe Maria Crespi.",
        Effects = new List<Effect>()
        {
            Effects.Weaken
        }
    };
    
    public static Card PrinceEugenPortrait = new()
    {
        Name = "Bildnis des Prinzen Eugen von Savoyen",
        Artist = Artists.Auerbach,
        Description = "A painting by the German painter and etcher Johann Gottfried Auerbach.",
        Effects = new List<Effect>()
        {
            Effects.Sublime
        }
    };
    
    public static Card ElisabethChristinePortrait = new()
    {
        Name = "Elisabeth Christine von Braunschweig-Wolfenbüttel",
        Artist = Artists.Auerbach,
        Description = "A painting by the German painter and etcher Johann Gottfried Auerbach.",
        Effects = new List<Effect>()
        {
            Effects.Charm
        }
    };
    
    public static Card PrinceEugenCommanderPortrait = new()
    {
        Name = "Prinz Eugen von Savoyen als Feldherr",
        Artist = Artists.Auerbach,
        Description = "A painting by the German painter and etcher Johann Gottfried Auerbach.",
        Effects = new List<Effect>()
        {
            Effects.Sublime
        }
    };
    
    public static Card Attack = new()
    {
        Name = "Attack",
        Description = "The target is attacked.",
        Effects = new List<Effect>()
        {
            Effects.Attack
        }
    };
    
    public static Card Defense = new()
    {
        Name = "Defense",
        Description = "The target is defended.",
        Effects = new List<Effect>()
        {
            Effects.Defense
        }
    };
    
    public static Card Taunt = new()
    {
        Name = "Taunt",
        Description = "The target is taunted.",
        Effects = new List<Effect>()
        {
            Effects.Taunt
        }
    };

    public static Card Church = new()
    {
        Name = "Kirche in Unterach am Attersee",
        Artist = Artists.Klimt,
        Description = "A painting by the Austrian symbolist painter Gustav Klimt.",
        Effects = new List<Effect>()
        {
            Effects.Sleep
        }
    };



}