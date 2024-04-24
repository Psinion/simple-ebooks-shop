using SES.Domain.Entities.Base;

namespace SES.Domain.Entities;

public class Book : Entity
{
    public string Title { get; set; } = "";
    public string Annotation { get; set; } = "";

    public DateTime? PublicationDate;
}