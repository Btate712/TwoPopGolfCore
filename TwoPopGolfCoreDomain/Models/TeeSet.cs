namespace TwoPopGolfCoreDomain.Models;

public class TeeSet
{
    public string Name { get; private set; } = string.Empty;
    public float CourseRating { get; private set; }
    public float SlopeRating { get; private set; }
    public TeeSetHole[] Holes { get; private set; } = [];

    private TeeSet()
    {
    }
    
    public static TeeSet New()
    {
        return new TeeSet();
    }
    
    public TeeSet WithName(string name)
    {
        Name = name;
        return this;
    }

    public TeeSet WithCourseRating(float courseRating)
    {
        CourseRating = courseRating;
        return this;
    }

    public TeeSet WithSlopeRating(float slopeRating)
    {
        SlopeRating = slopeRating;
        return this;
    }

    public TeeSet WithHoles(TeeSetHole[] holes)
    {
        Holes = holes;
        return this;
    }

    public void Validate()
    {
        ValidateName();
        ValidateCourseRating();
        ValidateSlopeRating();
        ValidateHoles();
    }

    private void ValidateName()
    {
        if (string.IsNullOrEmpty(Name))
        {
            throw new Exception("Tee Set is not valid until Name is set.");
        }
    }

    private void ValidateCourseRating()
    {
        if (CourseRating == 0f)
        {
            throw new Exception("Tee Set is not valid until Course Rating is set.");
        }
    }
    
    private void ValidateSlopeRating()
    {
        if (SlopeRating == 0f)
        {
            throw new Exception("Tee Set is not valid until Slope Rating is set.");
        }
    }

    private void ValidateHoles()
    {
        ValidateHoleCount();
        ValidateHoleNumbersForHoleCount();
        ValidateHoleHandicapsForHoleCount();
    }

    private void ValidateHoleCount()
    {
        if (Holes.Length == 0)
        {
            throw new Exception("Tee Set is not valid until Holes are added.");
        }
    }
    private void ValidateHoleNumbersForHoleCount()
    {
        for (int i = 1; i <= Holes.Length; i++)
        {
            if (Holes.All(h => h.HoleNumber != i))
            {
                throw new Exception("Tee Set is not valid if Holes are not numbered 1 through [hole count]");
            }

        }
    }
    
    private void ValidateHoleHandicapsForHoleCount()
    {
        for (int i = 1; i <= Holes.Length; i++)
        {
            if (Holes.All(h => h.HoleHandicap != i))
            {
                throw new Exception("Tee Set is not valid if Holes are not numbered 1 through [hole count]");
            }

        }
    }
}