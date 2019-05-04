using Animals;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent MoveBehaviorFactory.
    /// </summary>
    public static class MoveBehaviorFactory
    {
        /// <summary>
        /// Factory to create the move behavior.
        /// </summary>
        /// <param name="type"> The type of move behavior.</param>
        /// <returns> Returns the behavior type. </returns>
        public static IMoveBehavior CreateMoveBehavior(MoveBehaviorType type)
        {
            IMoveBehavior result = null;

            switch (type)
            {
                case MoveBehaviorType.Fly:
                    result = new FlyBehavior();
                    break;

                case MoveBehaviorType.NoMove:
                    result = new NoMoveBehavior();
                    break;

                case MoveBehaviorType.Pace:
                    result = new PaceBehavior();
                    break;

                case MoveBehaviorType.Swim:
                    result = new SwimBehavior();
                    break;

                default:
                    break;
            }

            return result;
        }
    }
}
