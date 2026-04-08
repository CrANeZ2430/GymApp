namespace GymApp.Shared.Models.Exercises.Models;

[Flags]
public enum MuscleGroups
{
    None = 0,

    //Upper body
    Chest = 1 << 0,
    UpperBack = 1 << 1,
    Lats = 1 << 2,
    Traps = 1 << 3,
    LowerBack = 1 << 4,
    ShouldersFront = 1 << 5,
    ShouldersSide = 1 << 6,
    ShouldersRear = 1 << 7,
    Triceps = 1 << 8,
    Biceps = 1 << 9,
    Forearms = 1 << 10,

    //Core
    Abs = 1 << 11,
    Obliques = 1 << 12,

    //Lower body
    Quads = 1 << 13,
    Hamstrings = 1 << 14,
    Glutes = 1 << 15,
    Calves = 1 << 16,
    Adductors = 1 << 17,
    Abductors = 1 << 18
}
