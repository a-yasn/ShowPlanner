namespace ShowPlanner.Domain
{
    /// <summary>
    /// Show
    /// </summary>
    public class Show
    {
        /// <summary>
        /// Identity
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public virtual string Description { get; set; }

        public override string ToString()
        {
            return $"Id={Id}, Name={Name}, Description={Description}";
        }
    }
}
