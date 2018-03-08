namespace NetMud.DataStructure.Base.System
{
    /// <summary>
    /// A player's "user"
    /// </summary>
    public interface IAccount
    {
        /// <summary>
        /// Unique string key for player user accounts
        /// </summary>
        string GlobalIdentityHandle { get; set; }
    }
}
