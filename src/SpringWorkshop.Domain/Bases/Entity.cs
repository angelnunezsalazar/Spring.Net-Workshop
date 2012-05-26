namespace SpringWorkshop.Domain.Bases
{

    public class Entity
    {
        public virtual int Id { get; protected set; }

        private int? cachedHashCode;

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (null == compareTo || !GetType().IsInstanceOfType(compareTo))
                return false;

            if (ReferenceEquals(this, compareTo))
                return true;

            return !IsTransient() && 
                   !compareTo.IsTransient() && 
                   Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            if (!cachedHashCode.HasValue)
            {
                if (IsTransient())
                {
                    cachedHashCode = base.GetHashCode();
                }
                else
                {
                    unchecked
                    {
                        int hashCode = GetType().GetHashCode();
                        cachedHashCode = (hashCode * HASH_MULTIPLIER) ^ Id.GetHashCode();
                    }
                }
            }
            return cachedHashCode.Value;
        }

        public virtual bool IsTransient()
        {
            return Equals(Id, default(int));
        }

        private const int HASH_MULTIPLIER = 31;
    }
}