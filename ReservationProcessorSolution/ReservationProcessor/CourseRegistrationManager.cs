/*
 * We will ask the user for their:
 * Email Address
 * The ID of the course they'd like to take.
 * The ID of the offering of that course they'd like to take.
 * 
 * We will return to them:
 * (Happy Path): A message that says their are registered, and a registration ID, and the date of the course.
 * (Error): A message that says they cannot enroll for the course, and reason.
 */

public class CourseRegistrationManager
{

    public CourseRegistrationResponse RegisterForCourse(string? email, string? courseId, string? courseOfferingId)
    {
        var registered = !email.EndsWith("aol.com");
        return new CourseRegistrationResponse(Guid.NewGuid().ToString(), DateTime.Now.AddDays(15), registered);
    }

    public CourseRegistrationResponse RegisterForCourse(CourseRegistrationRequest request)
    {
        return RegisterForCourse(request.Email, request.CourseId, request.CourseOfferingId);
    }
}