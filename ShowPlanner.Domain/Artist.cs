namespace ShowPlanner.Domain
{
    public class Artist
    {
        /// <summary>
        /// Identity
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public virtual  string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public virtual string LastName { get; set; }

        public override string ToString()
        {
            return $"Id={Id}, FirstName={FirstName}, LastName={LastName}";
        }
    }
}
