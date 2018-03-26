namespace LearningSystem.Data
{
    public static class DataConstants
    {
        public const int ArticleTitleMinLength = 3;
        public const int ArticleTitleMaxLength = 100;

        public const int CourseNameMaxLength = 50;
        public const int CourseDescriptionMaxLength = 2000;

        public const int UsernameMinLength = 2;
        public const int UsernameMaxLength = 50;

        public const int CourseExamSubmissionFileLength = 2 * 1024 * 1024; // 2mb (2 * 1024 = 2kb * 1024 = 2mb)
    }
}
