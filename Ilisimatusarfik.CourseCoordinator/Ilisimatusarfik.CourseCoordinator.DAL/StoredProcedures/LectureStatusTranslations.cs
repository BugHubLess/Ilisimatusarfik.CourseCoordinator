using System;

namespace Ilisimatusarfik.CourseCoordinator.DAL.StoredProcedures
{
    public static class LectureStatusTranslations
    {
        internal const string Create = "SPCreateLectureStatusTranslation";
        internal const string Delete = "SPDeleteLectureStatusTranslations";
        internal const string GetSingle = "SPGetLectureStatusTranslation";
        internal const string GetMany = "SPGetLectureStatusTranslations";
        internal const string Update = "SPUpdateOrAddLectureStatusTranslation";
    }

    public struct Input
    {
        public readonly struct Create
        {
            public Create(string Status, string Locale)
            {
                this.Status = Status;
                this.Locale = Locale;
            }

            public string Status { get; }
            public string Locale { get; }
        }

        public readonly struct Delete
        {
            public Delete(int lectureStatusId)
            {
                LectureStatusID = lectureStatusId;
            }

            public int LectureStatusID { get; }
        }

        public readonly struct GetSingle
        {
            public GetSingle(int LectureStatusID, string Locale)
            {
                this.LectureStatusID = LectureStatusID;
                this.Locale = Locale;
            }

            public int LectureStatusID { get; }
            public string Locale { get; }
        }

        public readonly struct Update
        {
            public Update(int LectureStatusID, string Locale, string Status)
            {
                this.LectureStatusID = LectureStatusID;
                this.Locale = Locale;
                this.Status = Status;
            }
            public int LectureStatusID { get; }
            public string Locale { get; }
            public string Status { get; }
        }

        public readonly struct GetAll
        {
            public GetAll(string Locale)
            {
                this.Locale = Locale;
            }

            public string Locale { get; }
        }
    }

    public static class Output
    {
        internal const string ID = "id";
        internal const string ROWS = "rows";
    }
}