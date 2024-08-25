
using TwoPopGolfCoreDomain.Models;

namespace TwoPopGolfCoreDomainTests;

public class TeeSetTests
{
    private const string Name = "Test Name";
    private const float CourseRating = 72f;
    private const float SlopeRating = 113f;
    private const int HoleCount = 18;
    
    [Fact]
    public void Validate_ValidDataEntered_NoExceptionThrown()
    {
        // Arrange
        TeeSetHole[] teeSetHoles = GetValidHoles(HoleCount);
        TeeSet teeSet = TeeSet.New()
            .WithName(Name)
            .WithCourseRating(CourseRating)
            .WithSlopeRating(SlopeRating)
            .WithHoles(teeSetHoles);
        
        // Act (no Assertion needed since an exception would cause the test to fail)
        teeSet.Validate();
    }

    [Fact]
    public void Validate_NoName_Throws()
    {
        // Arrange
        TeeSetHole[] teeSetHoles = GetValidHoles(HoleCount);
        TeeSet teeSet = TeeSet.New()
            .WithCourseRating(CourseRating)
            .WithSlopeRating(SlopeRating)
            .WithHoles(teeSetHoles);  
        
        // Act
        void Action() => teeSet.Validate();

        // Assert
        Assert.Throws<Exception>(Action);
    }

    [Fact]
    public void Validate_NoCourseRating_Throws()
    {
        // Arrange
        TeeSetHole[] teeSetHoles = GetValidHoles(HoleCount);
        TeeSet teeSet = TeeSet.New()
            .WithName(Name)
            .WithSlopeRating(SlopeRating)
            .WithHoles(teeSetHoles);
                
        // Act
        void Action() => teeSet.Validate();

        // Assert
        Assert.Throws<Exception>(Action);
    }
    
    [Fact]
    public void Validate_NoSlopeRating_Throws()
    {
        // Arrange
        TeeSetHole[] teeSetHoles = GetValidHoles(HoleCount);
        TeeSet teeSet = TeeSet.New()
            .WithName(Name)
            .WithCourseRating(CourseRating)
            .WithHoles(teeSetHoles);
                
        // Act
        void Action() => teeSet.Validate();

        // Assert
        Assert.Throws<Exception>(Action);
    }
        
    [Fact]
    public void Validate_NoHoles_Throws()
    {
        // Arrange
        TeeSet teeSet = TeeSet.New()
            .WithName(Name)
            .WithSlopeRating(SlopeRating)
            .WithCourseRating(CourseRating);
                
        // Act
        void Action() => teeSet.Validate();

        // Assert
        Assert.Throws<Exception>(Action);
    }

    [Fact]
    public void Validate_InvalidHoleNumbers_Throws()
    {
        // Arrange
        TeeSetHole[] teeSetHoles = GetValidHoles(HoleCount);
        teeSetHoles[0].HoleNumber = HoleCount + 1;
        TeeSet teeSet = TeeSet.New()
            .WithName(Name)
            .WithCourseRating(CourseRating)
            .WithSlopeRating(SlopeRating)
            .WithHoles(teeSetHoles);
        
        // Act
        void Action() => teeSet.Validate();

        // Assert
        Assert.Throws<Exception>(Action);
    }
    
    [Fact]
    public void Validate_InvalidHandicapNumbers_Throws()
    {
        // Arrange
        TeeSetHole[] teeSetHoles = GetValidHoles(HoleCount);
        teeSetHoles[0].HoleHandicap = HoleCount + 1;
        TeeSet teeSet = TeeSet.New()
            .WithName(Name)
            .WithCourseRating(CourseRating)
            .WithSlopeRating(SlopeRating)
            .WithHoles(teeSetHoles);
        
        // Act
        void Action() => teeSet.Validate();

        // Assert
        Assert.Throws<Exception>(Action);
    }
    
    private TeeSetHole[] GetValidHoles(int holeCount)
    {
        TeeSetHole[] teeSetHoles = new TeeSetHole[holeCount];
        
        for (int i = 0; i < holeCount; i++)
        {
            TeeSetHole testHole = new()
            {
                HoleHandicap = i + 1,
                HoleNumber = i + 1
            };
            
            teeSetHoles[i] = testHole;
        }

        return teeSetHoles;
    }
}