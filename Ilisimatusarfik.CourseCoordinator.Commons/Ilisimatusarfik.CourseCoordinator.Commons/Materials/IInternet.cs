﻿namespace Ilisimatusarfik.CourseCoordinator.Commons.Materials
{
    using System;

    public interface IInternet : IResource
    {
        string URL { get; set; }
        DateTimeOffset Date { get; set; }
        string Title { get; set; }
    }
}
