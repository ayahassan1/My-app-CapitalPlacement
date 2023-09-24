public class ApplicationForm
{
    public byte[]? Cover_image { get; set; }
    public PersonalInfo? Summary { get; set; }
    public Profile? Description { get; set; }
    public List<AdditionQuestions>? Additional_questions { get; set; }
}
public class AdditionQuestions
{
    public string? Question { get; set; }
    public dynamic? Choice { get; set; }
}
public class PersonalInfo
{
    public string? First_name { get; set; }
    public string? Last_name { get; set; }
    public string? Email { get; set; }
    public Phone? phone_temp { get; set; }
    public Nationality? nationality_temp { get; set; }
    public CurrentResidence? currentresidence_temp { get; set; }
    public IDNumber? Id_temp { get; set; }
    public DateBirth? datebirth_temp { get; set; }
    public Gender? gender_temp { get; set; }
    public List<AdditionQuestions>? Additional_questions { get; set; }

}

public class Phone
{
    public bool? Internal { get; set; }
    public bool? Hide { get; set; }
}
public class Nationality
{
    public bool? Internal { get; set; }
    public bool? Hide { get; set; }
}
public class CurrentResidence
{
    public bool? Internal { get; set; }
    public bool? Hide { get; set; }
}
public class IDNumber
{
    public bool Internal { get; set; }
    public bool Hide { get; set; }
}
public class DateBirth
{
    public bool Internal { get; set; }
    public bool Hide { get; set; }
}
public class Gender
{
    public bool Internal { get; set; }
    public bool Hide { get; set; }
}
public class AdditionalQuestion
{
    public dynamic Type { get; set; }
    public string Question { get; set; }
}
public class Choice
{
    public string Type { get; set; }
}
public class AdditionalQuestionType1 : AdditionalQuestion
{

    public Choice choice_temp { get; set; }
    public bool Other_options { get; set; }

}
public class AdditionalQuestionType2 : AdditionalQuestion
{
    public bool Qualify_candidate { get; set; }

}
public class Profile
{
    public Education Education_temp { get; set; }
    public Experience Experience_temp { get; set; }
    public Resume Resume_temp { get; set; }
    public List<AdditionQuestions> Additional_questions { get; set; }
}
public class Education
{
    public bool Mandatory { get; set; }
    public bool Hide { get; set; }
    public string School { get; set; }
    public string Degree { get; set; }
    public string Course_name { get; set; }
    public string Location_study { get; set; }
    public DateTime Start_date { get; set; }
    public bool Currently_study { get; set; }

}
public class Experience
{
    public bool Mandatory { get; set; }
    public bool Hide { get; set; }
    public string Company { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public DateTime Start_date { get; set; }
    public DateTime End_date { get; set; }
    public bool Currently_employed { get; set; }
}
public class Resume
{
    public bool Mandatory { get; set; }
    public bool Hide { get; set; }
}
